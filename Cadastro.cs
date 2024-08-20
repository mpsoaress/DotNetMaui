using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;



namespace MauiApp1
{
    [Table("cadastros")]
    public class Cadastro
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        [MaxLength(250), Unique]
        public string? Cpf { get; set; }
        [MaxLength(13), Unique]
        public string? Nome { get; set; }
    }
}
