namespace FreeCourse.Shared.Messages
{
    public class CreateNameChangedEvent
    {
        public string CourseId { get; set; }
        public string UpdatedName { get; set; }
    }
}
