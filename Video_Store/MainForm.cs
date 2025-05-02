using Microsoft.EntityFrameworkCore;
using System.Xml.Linq;

namespace Video_Store
{
    public partial class MainForm : Form
    {
        public VideoStoreContext Context { get; set; }
        public MainForm()
        {
            InitializeComponent();
            Context = new VideoStoreContext();
            LoadTreeView();
            LoadDataGrid();
        }

        public void LoadTreeView()
        {
            treeView.Nodes.Clear();
            treeView.Nodes.Add("Movies");
            treeView.Nodes.Add("Customers");
            treeView.Nodes.Add("Rentals");
        }

        public void LoadDataGrid()
        {
            dataGridView.DataSource = null;
            dataGridView.Rows.Clear();

            var movies = Context.Movies.ToList();
            dataGridView.DataSource = movies.Select(m => new
            {
                m.ID,
                m.Title,
                //DirectorName = m.Director.Name,
                //DirectorBirthYear = m.Director.BirthYear,
                m.Genre,
                m.Country,
                m.Rating
            }).ToList();

            var customers = Context.Customers.ToList();
            dataGridView.DataSource = customers.Select(c => new
            {
                c.ID,
                c.Name,
                c.Email,
                c.PhoneNumber,
            }).ToList();

            var rentals = Context.Rentals.ToList();
            dataGridView.DataSource = rentals.Select(r => new
            {
                r.ID,
                r.CustomerID,
                r.MovieID,
                r.RentalDate,
                r.ReturnDate,
            }).ToList();
        }
        private void treeView_AfterSelect(object sender, TreeViewEventArgs e)
        {
            switch (e.Node.Text)
            {
                case "Movies":
                    LoadMovies();
                    break;
                case "Customers":
                    LoadCustomers();
                    break;
                case "Rentals":
                    LoadRentals();
                    break;
            }
        }
        private void LoadMovies()
        {
            var movies = Context.Movies.ToList();
            dataGridView.DataSource = movies.Select(m => new
            {
                m.ID,
                m.Title,
                //DirectorName = m.Director.Name,
                //DirectorBirthYear = m.Director.BirthYear,
                m.ReleaseYear,
                m.Genre,
                m.Country,
                m.Rating
            }).ToList();
        }
        private void LoadCustomers()
        {
            var customers = Context.Customers.ToList();
            dataGridView.DataSource = customers.Select(c => new
            {
                c.ID,
                c.Name,
                c.Email,
                c.PhoneNumber
            }).ToList();

        }

        private void LoadRentals()
        {
            var rentals = Context.Rentals.ToList();
            var rentalDetails = rentals.Select(r => new
            {
                r.ID,
                CustomerName = Context.Customers.Find(r.CustomerID)?.Name,
                MovieTitle = Context.Movies.Find(r.MovieID)?.Title,
                r.RentalDate,
                r.ReturnDate
            }).ToList();

            dataGridView.DataSource = rentalDetails;
        }

        private void buttonLoad_Click(object sender, EventArgs e)
        {
            XElement videoStore = XElement.Load("C:\\Users\\User\\source\\repos\\Video_Store\\Video_Store\\Data\\video_store.xml");

            foreach (var movie in videoStore.Element("Movies").Elements("Movie"))
            {
                int movieId = (int)movie.Element("ID");
                var existingMovie = Context.Movies.FirstOrDefault(m => m.ID == movieId);

                if (existingMovie == null)
                {
                    var newMovie = new Movie()
                    {
                        ID = (int)movie.Element("ID"),
                        Title = (string)movie.Element("Title"),
                        Director = new Director()
                        {
                            Name = (string)movie.Element("Director").Element("Name"),
                            BirthYear = (int)movie.Element("Director").Element("BirthYear")
                        },
                        ReleaseYear = (int)movie.Element("RealeseYear"),
                        Genre = (string)movie.Element("Genre"),
                        Country = (string)movie.Element("Country"),
                        Rating = (double)movie.Element("Rating")
                    };
                    Context.Movies.Add(newMovie);
                }

                foreach (var customer in videoStore.Element("Customers").Elements("Customer"))
                {
                    int customerId = (int)customer.Element("ID");
                    var existingCustomer = Context.Customers.FirstOrDefault(c => c.ID == customerId);

                    if (existingCustomer == null)
                    {
                        var newCustomer = new Customer()
                        {
                            ID = (int)customer.Element("ID"),
                            Name = (string)customer.Element("Name"),
                            Email = (string)customer.Element("Email"),
                            PhoneNumber = (string)customer.Element("PhoneNumber")
                        };

                        Context.Customers.Add(newCustomer);
                    }
                }
                foreach (var rental in videoStore.Element("Rentals").Elements("Rental"))
                {
                    int rentalId = (int)rental.Element("ID");
                    var existingRental = Context.Rentals.FirstOrDefault(c => c.ID == rentalId);

                    if (existingRental == null)
                    {
                        var newRental = new Rental()
                        {
                            ID = (int)rental.Element("ID"),
                            CustomerID = (int)rental.Element("CustomerID"),
                            MovieID = (int)rental.Element("MovieID"),
                            RentalDate = DateTime.Parse((string)rental.Element("RentalDate")),
                            ReturnDate = DateTime.Parse((string)rental.Element("ReturnDate"))
                        };

                        Context.Rentals.Add(newRental);
                    }
                }
            }
            MessageBox.Show("Данные загружены!");
        }
    }
}