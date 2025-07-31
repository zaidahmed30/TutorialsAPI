namespace TutorialsAPI.Models
{
    public class CourseDetail
    {
        public int CourseDetailId { get; set; }
        public int CourseId { get; set; }
        public int DurationId { get; set; }
        public float Fee { get; set; }
        public string BatchTime { get; set; }
        public string TopicCover { get; set; }
        public int TeacherId { get; set; }
        public string ShortDiscription { get; set; }
        public string LongDiscription { get; set; }
        public bool IsPublish { get; set; }
    }
}
