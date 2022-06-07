namespace Maplecodex2.Components.Notification
{
    public class NotificationMessage
    {
        public string? Title { get; set; }
        public string Message { get; set; } = "";
        public string Footer { get; set; } = "";
        public DateTime Date { get; set; } = DateTime.Now;
        public int? Duration { get; set; }
        public NotificationType Severity { get; set; } = NotificationType.Info;

        public string DateString
        {
            get => string.Format("{0,2:00}-{1,2:00}-{2,4:00} {3,2:00}:{4,2:00}", Date.Day, Date.Month, Date.Year, Date.Hour, Date.Minute);
        }
        public string ImgSrc
        {
            get => $"img/{Severity}.png";
        }
        public string ClassByType
        {
            get => $"box-{Severity}";
        }
        public string TitleByType
        {
            get => Title ??= Severity.ToString() + "!";
        }

        public static readonly NotificationMessage Default = new()
        {
            Title = "Info",
            Message = "This is a default constructed message.",
            Footer = "default.",
            Date = DateTime.Now,
            Duration = 5000,
            Severity = NotificationType.Info,
        };
    }
}
