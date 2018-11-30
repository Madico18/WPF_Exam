namespace CarDBSQLApplication_DAL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("TablesManufacturer")]
    public partial class TablesManufacturer
    {
        [Key]
        public int intManufacturerID { get; set; }

        [StringLength(50)]
        public string strManufacturerChecklistId { get; set; }

        [StringLength(50)]
        public string strName { get; set; }
    }
}
