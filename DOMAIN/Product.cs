using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DOMAIN
{
    public class Product
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Alias { set; get; }
        public decimal Price { get; set; }
        public decimal? PromotionPrice { set; get; }
        public decimal? OriginalPrice { set; get; }
        public int? Warranty { set; get; }
        public DateTime CreateDate { get; set; }
        public string Description { get; set; }
        public string Content { get; set; }
        [Column(TypeName = "xml")]
        public string MoreImages { set; get; }
        public bool? HotFlag { set; get; }
        public int CategoryID { set; get; }
        public int ProducerId { get; set; }
        public int SupplierId { get; set; }
        [ForeignKey("CategoryID")]
        public virtual ProductCategory ProductCategory { set; get; }
        [ForeignKey("ProducerId")]
        public virtual Producer Producer { set; get; }
        [ForeignKey("SupplierId")]
        public virtual Supplier Supplier { set; get; }
        public bool Status { get; set; }
        public virtual IEnumerable<Comment> Comments { set; get; }
        public virtual IEnumerable<OrderDetail> OrderDetails { set; get; }

        public virtual IEnumerable<ProductTag> ProductTags { set; get; }
    }
}
