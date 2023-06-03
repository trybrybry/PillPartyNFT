namespace PillPartyNFT.Models
{
    public class ErrorViewModel
    {
        public string? RequestId { get; set; }

        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
    }



    public class ClubsViewModel
    {
        int count { get; set;  }

        List<string> Clubs { get; set; }
        List<string> text { get; set; }
        List<string> percentage { get; set; }
        List<string> bullets { get; set; }

        public ClubsViewModel()
        {
            count = 0;
            Clubs = new List<string>();
            text = new List<string>();
            percentage = new List<string>();
            bullets = new List<string>();
        }

        public string GetCount()
        {
            if(count == 6)
            {
                return "0"; 
            }
            else
            {
                count = count++;
                return count.ToString(); 
            }
        }




    }
}