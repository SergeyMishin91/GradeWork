using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EstateAgency.Models
{
    public abstract class Estate
    {
        public int ID { get; set; }

        [Required(ErrorMessage = "Введите вид недвижимого имущества")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Введите тип недвижимого имущества")]
        public string Type { get; set; }

        [Required(ErrorMessage = "Введите инвентрарный номер недвижимого имущества")]
        //[RegularExpression(@"^[A-Z]+[a-zA-Z""'\s-]*$")]
        public string InventoryNumber { get; set; }

        [Required(ErrorMessage = "Введите год постройки недвижимого имущества")]
        [Range(1930, 2018/*DateTime.Now.ToOADate*/,
            ErrorMessage = "Год должен быть в пределах от {1} до {2}")]
        public int Year { get; set; }

        [Required(ErrorMessage = "Введите материал стен недвижимого имущества")]
        public string Wall { get; set; }

        [Required(ErrorMessage = "Введите площадь недвижимого имущества")]
        [Range(0.01, double.MaxValue,
            ErrorMessage = "Введите корректное значение площади")]
        public double Area { get; set; }

        [Required(ErrorMessage = "Введите адрес недвижимого имущества")]
        public string Adress { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime DateAdd
        {
            get
            {
                DateTime date = DateTime.Today.Date;
                return date;
            }
        }

        [Required(ErrorMessage = "Введите краткое описание недвижимого имущества")]
        public string ShortDescription { get; set; }

        [Required(ErrorMessage = "Введите описание недвижимого имущества")]
        public string LongDescription { get; set; }

        public string ImageURL { get; set; }

        public string ImageThumbURL { get; set; }

        public virtual bool SaleStatus { get; set; }

        public int ClientID { get; set; }

        public Client Owner { get; set; }
    }
}


