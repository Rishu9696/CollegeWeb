using Microsoft.AspNetCore.Mvc;
using CollegeWeb.Models; // Make sure this namespace has ContactViewModel and ContactMessage
using CollegeWeb.Data;   // Namespace where AppDbContext is located
using System.Threading.Tasks;

namespace CollegeWeb.Controllers
{
    public class HomeController : Controller
    {
        private readonly AppDbContext _context;

        // ✅ Constructor moved to top
        public HomeController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index() => View();

        public IActionResult About() => View();

        public IActionResult Courses() => View();

        public IActionResult Events() => View();

        public IActionResult Admission() => View();

        public IActionResult Differentator() => View();

        public IActionResult Message() => View();

        public IActionResult MCA() => View();

        public IActionResult MMS() => View();

        public IActionResult BMS() => View();

        public IActionResult MissionVision() => View();

        public IActionResult MediaSpeak() => View();

        // GET
        public IActionResult Contact()
        {
            return View();
        }

        // POST: receives fetch() request
        [HttpPost]
        [IgnoreAntiforgeryToken]
        public async Task<IActionResult> SubmitContact([FromBody] ContactViewModel model)
        {
            Console.WriteLine("✅ [SubmitContact] Hit");

            if (!ModelState.IsValid)
            {
                Console.WriteLine("❌ Invalid model state");
                return BadRequest("Invalid form data.");
            }

            Console.WriteLine($"Name: {model.Name}, Email: {model.Email}");

            var contactMessage = new ContactMessage
            {
                Name = model.Name,
                Email = model.Email,
                Subject = model.Subject,
                Message = model.Message
            };

            _context.ContactMessages.Add(contactMessage);
            await _context.SaveChangesAsync();

            Console.WriteLine("✅ Saved to DB");

            return Ok("Thank you for contacting us!");
        }



        public IActionResult CoreFaculty()
        {
            var facultyList = new List<Faculty>
        {
            new Faculty { Name = "Prof. Rashmi Pathak", Designation = "Assistant Professor", Description ="Prof. Rashmi Pathak holds a Master’s degree in Information Technology. With over 4 years of hands-on " +
            "experience in the industry, Miss Rashmi Pathak has significantly contributed to various prominent companies. She has worked with esteemed organizations like Tata Consultancy Services (TCS), Tata AIG, DCB, " +
            "and Convergys India, where she has showcased her proficiency in tackling complex challenges and delivering innovative solutions. She has an impressive teaching experience of more than 4 years, during which she" +
            " has mentored and inspired countless students in the field of Information Technology, Artificial Intelligence, and Data Science. Her areas of interest lie in Artificial Intelligence and Data Science." +
            "", ImageUrl = "/Images/faculty/Rshami-ma'am.png" },


            new Faculty { Name = "Prof. Shweta Nigam", Designation = "Assistant Professor", Description = "Prof. Shweta Nigam is a highly accomplished professional with a strong educational background" +
            " in Computer Science and Engineering. She holds a M.Tech (Computer Science and Engineering) and Master of Computer Applications degree(MCA). With over 11 years of teaching experience in academics" +
            ", she has refined her abilities in effectively conveying knowledge and providing guidance to students in their academic endeavours. She has contributed significantly to her field with the publication " +
            "of five research papers in reputed journals. She was a guide of many projects for Masters Students. Her interests revolve around different aspects of Cryptography and its applications."
            , ImageUrl = "/Images/faculty/Sweta-maam.png" },


            new Faculty { Name = "Dr. Neeta Bhatt", Designation = "Associate Professor", Description = "After completing her Master’s in computer applications, " +
            "she went ahead to get her Doctorate in Computer Science Her 16 years of experience in Education includes teaching Engineering, MCA and MBA students " +
            "She is a Guide for 5 PhD scholars She has a long experience of handling the examination department She is the Chairperson of Flying Squad Team at " +
            "Mumbai University Her core competency lies in managing websites * ASBM Faculty", ImageUrl = "/Images/faculty/neeta-maam.png" },


            new Faculty { Name = "Prof. Ramakrishnan Iyer", Designation = "Assistant Professor", Description = "Ramakrishnan Iyer holds a Executive MBA Post Graduate " +
            "Certificate from IIM, Kozhikode and B.Tech. in Electrical & Electronics Engineering. He is a Senior IT professional with 30+ years’ experience with rich " +
            "experience in the areas of Innovation, technology architect and delivery management and having a strong technology background, business development and " +
            "people leadership. He has a good experience in various automation technologies like RPA, Chatbots, and Machine Learning to drive process and productivity " +
            "improvements across the organization. His last role in Capgemini was as Financial Services Business Unit Automation Drive Lead, driving automation across" +
            " various financial services business unit accounts to drive improvements in processes and productivity for Application Managed services, Application " +
            "Development and Testing services thru Automation and Productivity Enhancements initiatives. He also has a Creative mindset being a part of Capgemini " +
            "Innovation groups driving business results through new innovation offering developed in emerging technologies.", ImageUrl = "/Images/faculty/Ramakrishnan-sir.png" },


            new Faculty { Name = "Dr. Sonali Kale", Designation = "Associate Professor - Finance", Description = "Dr. Sonali Kale holds a Doctoral Degree from SNDT Women’s " +
            "University of Mumbai. She has done her MBA in Financial Management, She holds M. Phil and M. Com. Degrees as well. She has a rich experience of more than a two " +
            "decade in academics. She has one Book and more than 23 research papers in her credit at in prestigious platforms like UGC Care and Scopus and holds two patents " +
            "that reflect innovative approach to education. Her area of Interest are Financial Management, Cost and Management Accounting, Financial Accounting."
            , ImageUrl = "/Images/faculty/saloni-maam.png" },


            new Faculty { Name = "Prof. Dinesh R Mehra", Designation = "Assistant Professor", Description = "Dinesh R Mehra holds Masters in Marketing Management from the University " +
            "of Mumbai. He has total work experience of 21 years, having worked for 09 years in companies like CMIE Pvt Ltd, ICICI Lombard GIC and SBI Factors and Commercial Services " +
            "Pvt Ltd Since the last 12 years he has been associated with academics and teaches various marketing subjects to first and second year students. He has also successfully steered" +
            " placement activities in his earlier assignments.", ImageUrl = "/Images/faculty/dinesh-sir.png" }
        };

            return View(facultyList);
        }

        public IActionResult AdjunctFaculty()
        {
            var adjunctFacultyList = new List<Faculty>
    {
        new Faculty { Name = "Prof. Amal S Roy", Designation = "Senior Faculty, Operations, Supply Chain & General Management", Description = "Senior Faculty, Operations, Supply Chain & General Management " +
        "Amal Roy is a Mechanical Engineer & Post Graduate in Industrial Engineering & Management from IIT, Kharagpur with brilliant academic records . Fellow of Institution of Engineers, Institution of " +
        "Industrial Engg. , Operational Research Society etc. He has over 30 years of corporate experience in senior positions in reputed Companies like ICI, GLAXO, DABUR, GHARDA CHEMICALS, SHREYA etc. " +
        "He held the position of General Manager Logistics in Glaxo , Profit Centre Head in Dabur, Director Strategy in Gharda, Executive Vice President - SCM in Shreya Life Sciences . His teaching" +
        " experience is for about 6 years full time & 12 years as Visiting Faculty. He has taught in various Management Institutes like NMIMS, Jamnalal Bajaj, Sydenham,NITIE, Durga Devi Saraf Institute " +
        "of Management Studies , IBS Powai, ITM, etc. He has also published technical papers, organised Industrial Seminars, Conclaves and developed Case Studies on real life industrial projects. His areas " +
        "of interest are Operations Management, Supply Chain Management, Strategic Management, Entrepreneurship Management, Creativity & Innovation, Total Quality Management, Project Management, World Class " +
        "Manufacturing , Service Operations Management, New Product Development etc. He has started Entrepreneurship Cell at Durga Devi Saraf Institute of Management Studies, Mumbai. He was Chairman," +
        " Placement for Durgadevi Saraf Institute of Management, Mumbai for some period & has good Corporate connections. He received the Best All India Best Faculty Award in Operations Management from " +
        "Dewang Mehta Business School Awards Committee.", ImageUrl = "/Images/faculty/amal-sir.png" },


        new Faculty { Name = "Hitesh Kaushal", Designation = "Marketing", Description = "Mr. Hitesh Kaushal holds Masters degree in Business Administration from Premiere Institute. With over 20 years " +
        "of Experience in industry with leading corporates in Real Estate and Infrastructure Sector. Having worked with Reliance Infrastructure and Airport Infrastructure Developers like GVK and K Raheja " +
        "Corp. Have achieved successful commercial launch of various projects. Prominent being Shopping Center projects of Inorbit Mall Malad, Korum Mall Thane, and new Terminal at Mumbai International " +
        "Airport. His areas of Interest include Integrated Marketing Communications, New Product Launches, Brand Development, and Commercial launch of Infrastructure projects.", ImageUrl = "/Images/faculty/hitesh-sir.png" }
    };

            return View(adjunctFacultyList);
        }


   




      

    }
}
