# Final Project

This project is for the BCIT 3618 Final Exam

##Current CONTRACT with all developers.

### Class
```
public class Title
{
	public string TitleId { get; set; }
	public string TitleType { get; set; }
	public string PrimaryTitle { get; set; }
	public string OriginalTitle { get; set; }
	public bool? IsAdult { get; set; }
	public short? StartYear { get; set; }
	public short? EndYear { get; set; }
	public int? RuntimeMinutes { get; set; }
	public string Genres { get; set; }
}
```

### Api Endpoints
```
/api/titles  = GET ALL (GET)
```
```
/api/titles/{string:TitleId} = Search for title id (GET)
```
```
/api/titles/{string:PrimaryTitle} = Search for title (GET)
```
```
/api/titles/{object:Title} = CREATE
```
```
/api/titles/{string:Title} = DELETE
```
```
/api/titles/{string:Title} = UPDATE
```
