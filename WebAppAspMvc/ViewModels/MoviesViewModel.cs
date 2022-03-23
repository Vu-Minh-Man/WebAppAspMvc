using System.Data;
using WebAppAspMvc.Dtos;

namespace WebAppAspMvc.ViewModels
{
    public class MoviesViewModel
    {
        public DataTable MoviesTable { get; }
        public IDictionary<string, bool>? IsHyperlinkColumn { get; }
        public IDictionary<int, string>? Hyperlinks { get; }

        public MoviesViewModel(IEnumerable<MovieDto> movies)
        {
            MoviesTable = new DataTable("MoviesTable");
            IsHyperlinkColumn = new Dictionary<string, bool>();
            Hyperlinks = new Dictionary<int, string>();

            DataColumn id = new DataColumn("id");
            id.DataType = Type.GetType("System.Int32");
            id.Caption = "ID";
            id.AllowDBNull = false;
            id.Unique = true;
            MoviesTable.Columns.Add(id);

            DataColumn title = new DataColumn("title");
            title.DataType = Type.GetType("System.String");
            title.Caption = "Title";
            MoviesTable.Columns.Add(title);
            IsHyperlinkColumn[title.ColumnName] = true;

            DataColumn genre = new DataColumn("genre");
            genre.DataType = Type.GetType("System.String");
            genre.Caption = "Genre";
            MoviesTable.Columns.Add(genre);

            DataColumn description = new DataColumn("description");
            description.DataType = Type.GetType("System.String");
            description.Caption = "Description";
            MoviesTable.Columns.Add(description);

            DataColumn rating = new DataColumn("rating");
            rating.DataType = Type.GetType("System.Single");
            rating.Caption = "Rating";
            MoviesTable.Columns.Add(rating);

            if (movies is not null)
            {
                foreach (var movie in movies)
                {
                    DataRow row = MoviesTable.NewRow();
                    row["id"] = movie.Id;
                    row["title"] = movie.Title;
                    row["genre"] = movie.GenreDto.Name;
                    row["description"] = movie.Description;
                    row["rating"] = movie.Rating;
                    MoviesTable.Rows.Add(row);
                    Hyperlinks[movie.Id] = @"Movies\Details\" + movie.Id;
                }
            }
        }
    }
}
