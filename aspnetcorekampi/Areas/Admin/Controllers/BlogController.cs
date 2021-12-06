using aspnetcorekampi.Areas.Admin.Models;
using ClosedXML.Excel;
using DataAccessLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace aspnetcorekampi.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class BlogController : Controller
    {
        public IActionResult BloglarExcelListesi()
        {
            using (var workbook = new XLWorkbook())
            {
                var worksheet = workbook.Worksheets.Add("Blog Listesi");
                worksheet.Cell(1, 1).Value = "Blog ID";
                worksheet.Cell(1, 2).Value = "Blog Adı";

                int BlogRowCount = 2; // ilk satırda başlık olacağı için 2. satırdan itibaren okumaya başlasın
                foreach (var item in BlogTitleList())
                {
                    worksheet.Cell(BlogRowCount, 1).Value = item.ID;
                    worksheet.Cell(BlogRowCount, 2).Value = item.BlogName;
                    BlogRowCount++;
                }

                using (var stream = new MemoryStream())
                {
                    workbook.SaveAs(stream);
                    var content = stream.ToArray();
                    return File(content, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "Blog Listesi.xlsx");
                }
            }

        }

        public List<BlogExcelModel> BlogTitleList()
        {
            List<BlogExcelModel> bm = new List<BlogExcelModel>();
            using (var c = new Context())
            {
                bm = c.Blogs.Select(x => new BlogExcelModel
                {
                    ID = x.BlogID,
                    BlogName = x.BlogTitle
                }).ToList();

            }
            return bm;
        }

        public IActionResult BlogExcellistesi()
        {
            return View();
        }
    }
}
