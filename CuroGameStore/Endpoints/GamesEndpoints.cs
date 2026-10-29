using CuroGameStore.Dtos;

namespace CuroGameStore.Endpoints;

public static class GamesEndpoints
{   
    const string GetGameEndpointName = "GetGame";
    private static readonly List<GameDto> games = [
        new (
            1, 
            "GTA VI",
            "Role-Play",
            69.99m,
            new DateOnly(2026, 11, 5)
        ),
        new (
            2,
            "FC-27",
            "Sports",
            99.99m,
            new DateOnly(2026, 9, 16)
        ),
        new (
            3,
            "Forza Horizon 6",
            "Racing",
            49.99m,
            new DateOnly(2025, 12, 24)
        )
    ];

    public static void MapGamesEndpoints(this WebApplication app)
    {

        var group = app.MapGroup("/games");

        group.MapGet("/", () => games);

        group.MapGet("/{id}", (int id) =>
        {
        var game = games.Find(game => game.Id == id );

        return game is null ? Results.NotFound() : Results.Ok();
        }).WithName(GetGameEndpointName);
        

        group.MapPost("/", (CreateGameDto newGame) =>
        {
            GameDto game = new (
                games.Count + 1,
                newGame.Name,
                newGame.Genre,
                newGame.Price,
                newGame.ReleaseDate
            );

            games.Add(game);

            return Results.CreatedAtRoute(GetGameEndpointName, new{id = game.Id}, game);
        });

        group.MapPut("/{id}", (int id, UpdateGameDto updatedGame) =>
        {
            var index = games.FindIndex(games => games.Id == id);

            if (index == -1)
            {
                return Results.NotFound();
            } 

            games[index] = new GameDto(
                id,
                updatedGame.Name,
                updatedGame.Genre,
                updatedGame.Price,
                updatedGame.ReleaseDate
            );
            return Results.NoContent();
        });

        group.MapDelete("/{id}", (int id) =>
        {
            games.RemoveAll(game => game.Id == id);

            return Results.NoContent();
        });
    }
}
