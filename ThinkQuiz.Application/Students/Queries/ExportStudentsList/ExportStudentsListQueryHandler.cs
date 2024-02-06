using ClosedXML.Excel;
using ErrorOr;
using MediatR;
using ThinkQuiz.Application.Common.Interfaces.Persistence.Repositories;
using ThinkQuiz.Domain.ClassAggregate;
using ThinkQuiz.Domain.StudentAggregate;
using ClassExceptions = ThinkQuiz.Domain.Common.Exceptions.Class.Exceptions;
using StudentExceptions = ThinkQuiz.Domain.Common.Exceptions.Student.Exceptions;

namespace ThinkQuiz.Application.Students.Queries.ExportStudentsList
{
    public class ExportStudentsListQueryHandler : IRequestHandler<ExportStudentsListQuery, ErrorOr<ExportStudentsListResult>>
	{
        private readonly IStudentRepository _studentRepository;
        private readonly IClassRepository _classRepository;

        public ExportStudentsListQueryHandler(IStudentRepository studentRepository, IClassRepository classRepository)
        {
            _studentRepository = studentRepository;
            _classRepository = classRepository;
        }

        public async Task<ErrorOr<ExportStudentsListResult>> Handle(ExportStudentsListQuery query, CancellationToken cancellationToken)
        {
            await Task.CompletedTask;
            // check class exists
            if (_classRepository.GetClassById(query.ClassId) is not Class @class)
            {
                return ClassExceptions.NotFoundClass;
            }

            // check teacher owner
            if (@class.TeacherId != query.TeacherId)
            {
                return ClassExceptions.NotOwnsClass;
            }

            // check student is not null
            var students = _studentRepository.GetStudentsByClassId(query.ClassId);

            if (students.Count == 0)
            {
                return StudentExceptions.NotFoundStudent;
            }

            students = students.OrderBy(x => x.User.FullName).ToList();

            string contentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
            string fileName = "Students_list_of_" + @class.Name;

            return GenerateExcelFile(students, contentType, fileName);
        }

        private static ErrorOr<ExportStudentsListResult> GenerateExcelFile(List<Student> students, string contentType, string fileName)
        {
            using (var workbook = new XLWorkbook())
            {
                IXLWorksheet worksheet = workbook.AddWorksheet(fileName);
                worksheet.Cell(1, 1).Value = "Number";
                worksheet.Cell(1, 2).Value = "First Name";
                worksheet.Cell(1, 3).Value = "Last Name";
                worksheet.Cell(1, 4).Value = "Gender";
                worksheet.Cell(1, 5).Value = "Date Of Birth";
                worksheet.Cell(1, 6).Value = "Email";
                worksheet.Cell(1, 7).Value = "Phone";

                CustomSheet(worksheet);

                for (int i = 1; i <= students.Count; i++)
                {
                    var fullName = students[i - 1].User.FullName;
                    string[] nameParts = fullName.Split(" ");
                    string firstName = string.Join(" ", nameParts.Take(nameParts.Length - 1));
                    string lastName = nameParts.Last();
                    worksheet.Cell(i + 1, 1).Value = i;
                    worksheet.Cell(i + 1, 2).Value = firstName;
                    worksheet.Cell(i + 1, 3).Value = lastName;
                    worksheet.Cell(i + 1, 4).Value = students[i - 1].User.Gender == true ? "Male" : "Female";
                    worksheet.Cell(i + 1, 5).Value = students[i - 1].User.DateOfBirth.ToString();
                    worksheet.Cell(i + 1, 6).Value = students[i - 1].User.Email;
                    worksheet.Cell(i + 1, 7).Value = students[i - 1].User.Phone;
                }

                using (var stream = new MemoryStream())
                {
                    workbook.SaveAs(stream);
                    var content = stream.ToArray();
                    return new ExportStudentsListResult(fileName, contentType, content);
                }
            }

            static void CustomSheet(IXLWorksheet worksheet)
            {
                // custom interface
                var headerRow = worksheet.Row(1);

                foreach (var cell in headerRow.Cells())
                {
                    cell.Style.Fill.BackgroundColor = XLColor.BlueRyb;
                    cell.Style.Font.FontColor = XLColor.White;
                    cell.Style.Font.Bold = true;
                    cell.Style.Alignment.Vertical = XLAlignmentVerticalValues.Center;
                    cell.Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                }

                // column fit content
                worksheet.Columns().AdjustToContents();
            }
        }
    }
}

