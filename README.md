# Final Project

This project is for the BCIT 3618 Final Exam

##Current CONTRACT with all developers.

### Class
```
Movie
{
    Title {get; set; } maps from PrimaryTitle
    Genre {get; set; } maps from Genre
    IsAdult {get; set; }
    Year { get; set; }  maps from StartYear
    RunTimeMinutes { get; set; }
}
```

### Api Endpoints
```
/api/movies  = GET ALL (GET)
```
```
/api/movies/{integer:currentPage}/search/{string:genre} = Search from Genre (GET) P.S. For new searches this should be passed in as `0` originally. Genre will be url encoded as it can contain `,`.
```
```
/api/movies/{object:Movie} = CREATE
```
```
/api/movies/{string:Title} = DELETE
```
```
/api/movies/{string:Title} = Update
```
