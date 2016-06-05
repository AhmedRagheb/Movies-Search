<h1>Movies-Search</h1>
<p>
Movies App is a web application search for movies, used two services (Omdb, themoviesDB) and enabled user to check the movie details (rate, description, release date), watch movie trailer (YouTube service) and share trailer on social media channels. 
</p>

<ul>
<li>Web Application that helps you to search for movie trailers</li>
<li>Cache result using HTTP cache</li>
<li>I Used an API of an online movie database (TheMovieDb, Omdb) </li>
<li>I Used an API of an online video service (YouTube)</li>
</ul>

<h2>Tools and Technology</h2>
<ul>
<li>.Net Framework 4.5.2</li>
<li>C#</li>
<li>MVC 5</li>
<li>Bootstrap.</li>
<li>JavaScript and JQuery</li>
<li>Visual Studio 2015</li>
<li>StructureMap</li>
</ul>

<h2>Expandability</h2>
-	I create Factory Classes for Services and Services Configuration registered in IoC.  If we need to add new service, just implement same interface and add it in factory, also for configuration class, if we need to upgrade or downgrade configuration or change key from testing to production, very easy to handle that.

<h2>Performance</h2>
<ul>
<li>	Movies Search result are cached in memory, so very fast to retrieve for users.
<li>	Embedded Video loaded Ajax when user click on selected movie, so just one embedded in loaded in page.
</ul>

<h2>Architecture:</h2>
<ul>
<li>
<h4>Movies.Web</h4>
<span>ASP.net MVC web layer.</span>
</li>
<li>
<h4>Movies.Repository</h4>
<span>Class Library, act as logic layer that communicate with services layer to fetch data. Repository communicate with services using interfaces registered in IoC.</span>
</li>
<li>
<h4>Movies.Services</h4>
<span>Class Library, responsible for communicate with 3rd party API to get movies data and trailers, every service has configuration class to be easily to update or downgrade any service. And all configurations and service controlled by Factory classes.</span>
</li>
<li>
<h4>Movies.Models</h4>
<span>Class Library for Services and Repository Models.</span>
</li>
<li>
<h4>Movies.Contracts</h4>
<span>Class Library for all interfaces to be easily to use and register using any service.</span>
</li>
<li>
<h4>Movies.Helpers</h4>
<span>Class Library for helper classes.</span>
</li>
<li>
<h4>Movies.Tests</h4>
<span>Unit Testing, I used integration testing for services and repositories, I created real objects and connect to services directly to test real scenarios.</span>
</li>
</ul>


<h2>Questions and Contributions</h2>

<ul>
<li>If you found a bug or have a feature request, please report an issue or a pull request.</li>
<li>If you have a question, feel free to contact me (a.raghebmail@gmail.com)</li>
</ul>
