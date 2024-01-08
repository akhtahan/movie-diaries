using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Models
{
public class RecommendedMovie
{
    public string Genre { get; set; }
    public List<Movie> Movies { get; set; }
}

}