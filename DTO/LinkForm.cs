
using System.ComponentModel.DataAnnotations;

namespace shortLinkApp.DTO
{
    public class LinkForm
    {
        [Required]
        [RegularExpression(@"(?<Protocol>\w+):\/\/(?<Domain>[\w@][\w.:@]+)\/?[\w\.?=%&=\-@/$,]*")]
        public string url { get; set; }
    }
}
