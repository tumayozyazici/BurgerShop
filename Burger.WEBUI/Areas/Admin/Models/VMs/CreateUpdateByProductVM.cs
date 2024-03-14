using System.ComponentModel;

namespace Burger.WEBUI.Areas.Admin.Models.VMs
{
    public class CreateUpdateByProductVM
    {
        public int Id { get; set; }
        [DisplayName("Ürün Adı")]
        public string Name { get; set; }

        [DisplayName("Fiyatı")]
        public double Price { get; set; }

        public string? Photo { get; set; }

        [DisplayName("Açıklama")]
        public string? Description { get; set; }
    }
}
