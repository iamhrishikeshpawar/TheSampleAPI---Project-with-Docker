using System.Data.SqlTypes;
using TheSampleAPI.Data;

namespace TheSampleAPI.Endpoints
{
    public static class CourseEndpoints
    {
        public static void AddCourseEndpoints( this WebApplication app)
        {
            app.MapGet("/courses", (LoadAllCourses ));
            app.MapGet("/courses/{id}", LoadCoursebyId);
        }

        private static async Task<IResult> LoadAllCourses
            (CourseData data,
            string ? courseType,
            string ? search,
            int ? delay)
        {
            var output = data.Courses;
            if (string.IsNullOrWhiteSpace(courseType) == false )
            {
                output.RemoveAll(x => string.Compare(
                    x.CourseType,
                    courseType,
                    StringComparison.OrdinalIgnoreCase) != 0);
            }

            if (string.IsNullOrWhiteSpace(search) == false)
            {
                output.RemoveAll(x =>!x.CourseName.Contains
                (search,
                    StringComparison.OrdinalIgnoreCase)&&
                    !x.ShortDescription.Contains
                    (search,StringComparison.OrdinalIgnoreCase));
            }

            if (delay is not null)
            {
                if (delay > 300000)
                {
                    delay = 300000;
                }
                await Task.Delay((int)delay);
            }

            return Results.Ok( output);
        }
        private static async Task<IResult> LoadCoursebyId(CourseData data, int id, int? delay)
        {
            var output = data.Courses.SingleOrDefault(x => x.Id == id);
            if (delay is not null)
            {
                if (delay > 300000)
                {
                    delay = 300000;
                }
                await Task.Delay((int)delay);
            }

            if (output == null)
            {
                return Results.NotFound();
            }
            else
            {
                return Results.Ok(output);
            }

                
        }
    }
}
