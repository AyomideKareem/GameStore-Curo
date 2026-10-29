namespace CuroGameStore.Models;

public class Game
{
    public int Id {get; set;}
    public required string Name {get; set;}
    public Genre? Genre {get; set;}
    public int GenreId {get; set;} //foreign key 

    public decimal Price {get; set;}
    public DateOnly ReleaseDate {get; set;}

}
