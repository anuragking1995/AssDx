using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Deltax
{
    public class DeltaXRepository
    {
        private DeltaXDBContext Context { get; set; }
        public DeltaXRepository()
        {
            Context = new DeltaXDBContext();
        }
        public List<Actor> GetActorsUsingLinq()
        {
            List<Actor> lstActors = null;
            try
            {
                lstActors = (from c in Context.Actors select c).ToList<Actor>();
            }
            catch
            {
                lstActors = null;
            }
            return lstActors;
        }
        public List<Movie> GetMoviesUsingLinq()
        {
            List<Movie> lstMovies = null;
            try
            {
                lstMovies = (from c in Context.Movies select c).ToList<Movie>();
            }
            catch
            {
                lstMovies = null;
            }
            return lstMovies;
        }
        public List<Producer> GetProducersUsinglinq()
        {
            List<Producer> lstProducer = null;
            try
            {
                lstProducer = (from c in Context.Producers select c).ToList<Producer>();
            }
            catch
            {
                lstProducer = null;
            }
            return lstProducer;
        }
        public bool AddActor(string name, string sex, string dob, string bio)
        {
            bool status = false;
            if (sex == "Male")
            {
                sex = "M";
            }
            else
            {
                sex = "F";
            }
            try
            {
                Actor actor = new Actor();
     
                var objParameter = new ObjectParameter("actorID",typeof(string));
                int reurnVal = Context.usp_ActorID(objParameter);
                actor.ActorID = objParameter.Value.ToString();
                actor.ActorName =name;
                actor.Bio = bio;
                actor.Sex = sex;
                actor.DOB = Convert.ToDateTime(dob).Date;
                Context.Actors.Add(actor);
                Context.SaveChanges();
                status = true;

            }
            catch
            {
                status = false;
            }
            return status;
        }

        public bool AddProducer(string name,string sex,string dob,string bio)
        {
            bool status = false;
            if(sex=="Male")
            {
                sex = "M";
            }
            else
            {
                sex = "F";
            }
            try
            {
                Producer prod = new Producer();

                var objParameter = new ObjectParameter("producerID", typeof(string));
                int reurnVal = Context.usp_ProducerID(objParameter);
                prod.ProducerID = objParameter.Value.ToString();
                prod.ProducerName = name;
                prod.Bio = bio;
                prod.Sex = sex;
                prod.DOB = Convert.ToDateTime(dob);
                Context.Producers.Add(prod);
                Context.SaveChanges();
                status = true;

            }
            catch
            {
                status = false;
            }
            return status;
        }
        public bool AddMovie(string name, string yearOfRelease, string Plot, string producer, string[] actors)
        {
            bool status = false;
            try
            {
                Movie movie = new Movie();

                var objParameter = new ObjectParameter("movieID", typeof(string));
                int reurnVal = Context.usp_MovieID(objParameter);
                movie.MovieId = objParameter.Value.ToString();
                movie.MovieName = name;
                movie.YearOfRelease = Convert.ToInt16(yearOfRelease.Trim());
                movie.Plot = Plot;
                string prodID = (from c in Context.Producers where c.ProducerName==producer.Trim() select c.ProducerID ).FirstOrDefault().ToString();
                movie.ProducerID = prodID;
                Context.Movies.Add(movie);
                foreach(string var in actors)
                {
                    ActorMovie obj = new ActorMovie();
                    var objParameter1 = new ObjectParameter("iD", typeof(string));
                    int reurnVal1 = Context.usp_ActorMovie(objParameter1);
                    obj.PKActorMovie = Convert.ToInt32(objParameter1.Value);
                    string actorID = (from c in Context.Actors where c.ActorName == var.Trim() select c.ActorID).FirstOrDefault().ToString();
                    obj.MovieID = movie.MovieId;
                    obj.ActorID = actorID;
                    Context.ActorMovies.Add(obj);
                }
                Context.SaveChanges();
                status = true;

            }
            catch
            {
                status = false;
            }
            return status;
        }

        public bool updateMovies(Movie obj)
        {
            bool status = false;
            try
            {
                Movie movieObj = Context.Movies.Where(e => e.MovieId == obj.MovieId).FirstOrDefault<Movie>();
                movieObj.MovieName = obj.MovieName;
                movieObj.YearOfRelease = obj.YearOfRelease;
                movieObj.Plot = obj.Plot;
                Context.SaveChanges();
                status = true;
            }
            catch
            {
                return false;
            }
            return status;
        }
        public List<string> GetProducerNames()
        {
            List<string> names = new List<string>();
            try
            {
                names = (from c in Context.Producers select c.ProducerName).ToList();
            }
            catch
            {
                return null;
            }
            return names;
        }
        public List<string> GetActorNames()
        {
            List<string> names = new List<string>();
            try
            {
                names = (from c in Context.Actors select c.ActorName).ToList();
            }
            catch
            {
                return null;
            }
            return names;
        }
    }
}
