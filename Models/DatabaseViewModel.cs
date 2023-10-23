using System.Collections;

namespace App.Models
{
    public class DatabaseViewModel<T> where T : class
    {
        public List<T> Entities { get; set; } = new();
    }
}
