using Microsoft.AspNetCore.Mvc;
using Xceed.Words.NET;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ThinkQuiz.Api.Controllers.V1
{
    public class ExamController : ApiController
    {

        [HttpPost("exams")]
        public async Task<IActionResult> UploadExamDocx(IFormFile file)
        {
            if (file == null || file.Length == 0)
            {
                return BadRequest("No file uploaded.");
            }

            // Đọc nội dung của tệp docx
            using (var stream = new MemoryStream())
            {
                await file.CopyToAsync(stream);
                using (var document = DocX.Load(stream))
                {
                    string content = document.Text;

                    return Ok(content);
                }
            }
        }
    }
}

