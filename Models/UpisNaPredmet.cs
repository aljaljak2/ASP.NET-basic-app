using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplicationStelovanjeBaze.Models
{
    public class UpisNaPredmet
    {
        [Key]
        public int ID { get; set; }

        [ForeignKey("Student")]
        public int StudentId { get; set; }
        public Student Student { get; set; }  // ← dodaj ovo

        [ForeignKey("Predmet")]
        public int PredmetId { get; set; }
        public Predmet Predmet { get; set; }  // ← dodaj ovo

        public UpisNaPredmet() { }
    }
}
