using ETrade.Entity.Concretes;

namespace ETrade.Ui.Models.ViewModels
{
    public class UsersModel
    {
        public Users Users { get; set; }
        public List<County> Counties { get; set; }
        public string Msg { get; set; }
    }
}
