namespace StudentPortal.Web.Models
{

    // class of ViewModel to pass data to the student controller
    public class AddStudentsViewModel
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public bool Subscribed { get; set; }
    }
}
