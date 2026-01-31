using Life_Insurance.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Life_Insurance.Controllers
{
    public class AdminController : Controller
    {
        private Mycontext _context;
        private IWebHostEnvironment _env;
        public AdminController(Mycontext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }

        public IActionResult Index()
        {
            string row = HttpContext.Session.GetString("adminsession");
            if (row != null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("login");
            }
        }

        public IActionResult login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult login(string adminemail, string adminpassword)
        {
            var record = _context.tbl_admin.FirstOrDefault(a => a.admin_email == adminemail);
            if (record != null && record.admin_password == adminpassword)
            {
                HttpContext.Session.SetString("adminsession", record.admin_id.ToString());
                return RedirectToAction("index");
            }
            else
            {
                ViewBag.message = "Incorrect Email or Password";
                return View();
            }
        }

        public IActionResult logout()
        {
            HttpContext.Session.Remove("adminsession");
            return RedirectToAction("login");
        }

        public IActionResult profile()
        {
            var abcadminid = HttpContext.Session.GetString("adminsession");
            if (string.IsNullOrEmpty(abcadminid))
            {
                return RedirectToAction("login");
            }

            var row = _context.tbl_admin.Where(a => a.admin_id == int.Parse(abcadminid)).ToList();
            return View(row);
        }

        [HttpPost]
        public IActionResult profile(IFormFile admin_image, Admin admin)
        {
            // Retrieve the current admin data from the database
            var existingAdmin = _context.tbl_admin.FirstOrDefault(a => a.admin_id == admin.admin_id);

            if (existingAdmin == null)
            {
                // Handle case where the admin does not exist (error handling)
                return NotFound();
            }

            // If an image is provided, update the admin_image
            if (admin_image != null)
            {
                // Save the new image
                string getname = Path.GetFileName(admin_image.FileName);
                string imagepath = Path.Combine(_env.WebRootPath, "admin_images", getname);

                using (FileStream fs = new FileStream(imagepath, FileMode.Create))
                {
                    admin_image.CopyTo(fs);
                }

                // Update the image name in the admin object
                existingAdmin.admin_image = getname;
            }

            // Update the text fields even if image is not uploaded
            existingAdmin.admin_name = admin.admin_name;
            existingAdmin.admin_email = admin.admin_email;
            existingAdmin.admin_password = admin.admin_password;
            existingAdmin.admin_phone = admin.admin_phone;

            // Save changes to the database
            _context.tbl_admin.Update(existingAdmin);
            _context.SaveChanges();

            // Redirect to the profile page after the update
            return RedirectToAction("profile");
        }

        public IActionResult fetchuser(string textsearch)
        {
            var abcadminid = HttpContext.Session.GetString("adminsession");
            if (string.IsNullOrEmpty(abcadminid))
            {
                return RedirectToAction("login");
            }

            List<User> user = new List<User>();
            if (string.IsNullOrEmpty(textsearch))
            {
                user = _context.tbl_users.ToList();
            }
            else
            {
                user = _context.tbl_users.FromSqlInterpolated($"select * from tbl_users where user_id LIKE {textsearch} OR user_firstname LIKE {textsearch} OR user_lastname LIKE {textsearch} OR user_email LIKE {textsearch} OR user_password LIKE {textsearch} OR user_cnic LIKE {textsearch} OR user_dateofbirth LIKE {textsearch} OR user_phone LIKE {textsearch} OR user_address LIKE {textsearch}").ToList();
            }
            return View(user);
        }

        public IActionResult userdetails(int id)
        {
            return View(_context.tbl_users.FirstOrDefault(c => c.user_id == id));
        }

        public IActionResult userupdate(int id)
        {
            return View(_context.tbl_users.Find(id));
        }

        [HttpPost]
        public IActionResult userupdate(IFormFile user_image, User user)
        {
            // Retrieve the current admin data from the database
            var existingUser = _context.tbl_users.FirstOrDefault(u => u.user_id == user.user_id);

            if (existingUser == null)
            {
                // Handle case where the admin does not exist (error handling)
                return NotFound();
            }

            // If an image is provided, update the admin_image
            if (user_image != null)
            {
                // Save the new image
                string getname = Path.GetFileName(user_image.FileName);
                string imagepath = Path.Combine(_env.WebRootPath, "user_images", getname);

                using (FileStream fs = new FileStream(imagepath, FileMode.Create))
                {
                    user_image.CopyTo(fs);
                }

                // Update the image name in the admin object
                existingUser.user_image = getname;
            }

            // Update the text fields even if image is not uploaded
            existingUser.user_firstname = user.user_firstname;
            existingUser.user_lastname = user.user_lastname;
            existingUser.user_email = user.user_email;
            existingUser.user_password = user.user_password;
            existingUser.user_cnic = user.user_cnic;
            existingUser.user_dateofbirth = user.user_dateofbirth;
            existingUser.user_phone = user.user_phone;
            existingUser.user_address = user.user_address;

            // Save changes to the database
            _context.tbl_users.Update(existingUser);
            _context.SaveChanges();

            // Redirect to the profile page after the update
            return RedirectToAction("fetchuser");
        }

        public IActionResult userdelete(int id)
        {
            var deleteuserid = _context.tbl_users.Find(id);
            _context.tbl_users.Remove(deleteuserid);
            _context.SaveChanges();
            return RedirectToAction("fetchuser");
        }

        public IActionResult policytype()
        {
            return View();
        }

        [HttpPost]
        public IActionResult policytype(PolicyType policytype)
        {
            _context.tbl_policytype.Add(policytype);
            _context.SaveChanges();
            return View();
        }

        public IActionResult fetchpolicy(string textsearch)
        {
            var abcadminid = HttpContext.Session.GetString("adminsession");
            if (string.IsNullOrEmpty(abcadminid))
            {
                return RedirectToAction("login");
            }

            List<PolicyType> policytype = new List<PolicyType>();
            if (string.IsNullOrEmpty(textsearch))
            {
                policytype = _context.tbl_policytype.ToList();
            }
            else
            {
                policytype = _context.tbl_policytype.FromSqlInterpolated($"select * from tbl_policytype where policytype_id LIKE {textsearch} OR policytype_name LIKE {textsearch}").ToList();
            }
            return View(policytype);
        }

        public IActionResult policytypeupdate(int id)
        {
            return View(_context.tbl_policytype.Find(id));
        }

        [HttpPost]
        public IActionResult policytypeupdate(PolicyType policytype)
        {
            _context.tbl_policytype.Update(policytype);
            _context.SaveChanges();
            return RedirectToAction("fetchpolicy");
        }

        public IActionResult policytypedelete(int id)
        {
            var deletepolicytypeid = _context.tbl_policytype.Find(id);
            _context.tbl_policytype.Remove(deletepolicytypeid);
            _context.SaveChanges();
            return RedirectToAction("fetchpolicy");
        }

        public IActionResult transactiontype()
        {
            return View();
        }

        [HttpPost]
        public IActionResult transactiontype(TransactionType transactiontype)
        {
            _context.tbl_transactiontype.Add(transactiontype);
            _context.SaveChanges();
            return View();
        }

        public IActionResult fetchtransaction(string textsearch)
        {
            var abcadminid = HttpContext.Session.GetString("adminsession");
            if (string.IsNullOrEmpty(abcadminid))
            {
                return RedirectToAction("login");
            }

            List<TransactionType> transactiontype = new List<TransactionType>();
            if (string.IsNullOrEmpty(textsearch))
            {
                transactiontype = _context.tbl_transactiontype.ToList();
            }
            else
            {
                transactiontype = _context.tbl_transactiontype.FromSqlInterpolated($"select * from tbl_transactiontype where transactiontype_id LIKE {textsearch} OR transactiontype_name LIKE {textsearch}").ToList();
            }
            return View(transactiontype);
        }

        public IActionResult transactiontypeupdate(int id)
        {
            return View(_context.tbl_transactiontype.Find(id));
        }

        [HttpPost]
        public IActionResult transactiontypeupdate(TransactionType transactiontype)
        {
            _context.tbl_transactiontype.Update(transactiontype);
            _context.SaveChanges();
            return RedirectToAction("fetchtransaction");
        }

        public IActionResult transactiontypedelete(int id)
        {
            var deletetransactiontypeid = _context.tbl_transactiontype.Find(id);
            _context.tbl_transactiontype.Remove(deletetransactiontypeid);
            _context.SaveChanges();
            return RedirectToAction("fetchtransaction");
        }

        public IActionResult termplanyearlymonthly()
        {
            return View();
        }

        [HttpPost]
        public IActionResult termplanyearlymonthly(TermPlanYearlyMonthly termplanyearlymonthly)
        {
            _context.tbl_termplanyearlymonthly.Add(termplanyearlymonthly);
            _context.SaveChanges();
            return View();
        }

        public IActionResult fetchtermplanyearlymonthly(string textsearch)
        {
            var abcadminid = HttpContext.Session.GetString("adminsession");
            if (string.IsNullOrEmpty(abcadminid))
            {
                return RedirectToAction("login");
            }

            List<TermPlanYearlyMonthly> termplanyearlymonthly = new List<TermPlanYearlyMonthly>();
            if (string.IsNullOrEmpty(textsearch))
            {
                termplanyearlymonthly = _context.tbl_termplanyearlymonthly.ToList();
            }
            else
            {
                termplanyearlymonthly = _context.tbl_termplanyearlymonthly.FromSqlInterpolated($"select * from tbl_termplanyearlymonthly where termplanyearlymonthly_id LIKE {textsearch} OR termplanyearlymonthly_name LIKE {textsearch}").ToList();
            }
            return View(termplanyearlymonthly);
        }

        public IActionResult termplanyearlymonthlyupdate(int id)
        {
            return View(_context.tbl_termplanyearlymonthly.Find(id));
        }

        [HttpPost]
        public IActionResult termplanyearlymonthlyupdate(TermPlanYearlyMonthly termplanyearlymonthly)
        {
            _context.tbl_termplanyearlymonthly.Update(termplanyearlymonthly);
            _context.SaveChanges();
            return RedirectToAction("fetchtermplanyearlymonthly");
        }

        public IActionResult termplanyearlymonthlydelete(int id)
        {
            var deletetermplanyearlymonthlyid = _context.tbl_termplanyearlymonthly.Find(id);
            _context.tbl_termplanyearlymonthly.Remove(deletetermplanyearlymonthlyid);
            _context.SaveChanges();
            return RedirectToAction("fetchtermplanyearlymonthly");
        }

        public IActionResult termplanyearly()
        {
            return View();
        }

        [HttpPost]
        public IActionResult termplanyearly(TermPlanYearly termplanyearly)
        {
            _context.tbl_termplanyearly.Add(termplanyearly);
            _context.SaveChanges();
            return View();
        }

        public IActionResult fetchtermplanyearly(string textsearch)
        {
            var abcadminid = HttpContext.Session.GetString("adminsession");
            if (string.IsNullOrEmpty(abcadminid))
            {
                return RedirectToAction("login");
            }

            List<TermPlanYearly> termplanyearly = new List<TermPlanYearly>();
            if (string.IsNullOrEmpty(textsearch))
            {
                termplanyearly = _context.tbl_termplanyearly.ToList();
            }
            else
            {
                termplanyearly = _context.tbl_termplanyearly.FromSqlInterpolated($"select * from tbl_termplanyearly where termplanyearly_id LIKE {textsearch} OR termplanyearly_name LIKE {textsearch}").ToList();
            }
            return View(termplanyearly);
        }

        public IActionResult termplanyearlyupdate(int id)
        {
            return View(_context.tbl_termplanyearly.Find(id));
        }

        [HttpPost]
        public IActionResult termplanyearlyupdate(TermPlanYearly termplanyearly)
        {
            _context.tbl_termplanyearly.Update(termplanyearly);
            _context.SaveChanges();
            return RedirectToAction("fetchtermplanyearly");
        }

        public IActionResult termplanyearlydelete(int id)
        {
            var deletetermplanyearlyid = _context.tbl_termplanyearly.Find(id);
            _context.tbl_termplanyearly.Remove(deletetermplanyearlyid);
            _context.SaveChanges();
            return RedirectToAction("fetchtermplanyearly");
        }

        public IActionResult news()
        {
            return View();
        }

        [HttpPost]
        public IActionResult news(News news)
        {
            _context.tbl_news.Add(news);
            _context.SaveChanges();
            return View();
        }

        public IActionResult fetchnews(string textsearch)
        {
            var abcadminid = HttpContext.Session.GetString("adminsession");
            if (string.IsNullOrEmpty(abcadminid))
            {
                return RedirectToAction("login");
            }

            List<News> news = new List<News>();
            if (string.IsNullOrEmpty(textsearch))
            {
                news = _context.tbl_news.ToList();
            }
            else
            {
                news = _context.tbl_news.FromSqlInterpolated($"select * from tbl_news where news_id LIKE {textsearch} OR news_title LIKE {textsearch} OR news_description LIKE {textsearch}").ToList();
            }
            return View(news);
        }

        public IActionResult newsupdate(int id)
        {
            return View(_context.tbl_news.Find(id));
        }

        [HttpPost]
        public IActionResult newsupdate(News news)
        {
            _context.tbl_news.Update(news);
            _context.SaveChanges();
            return RedirectToAction("fetchnews");
        }

        public IActionResult newsdelete(int id)
        {
            var deletenewsid = _context.tbl_news.Find(id);
            _context.tbl_news.Remove(deletenewsid);
            _context.SaveChanges();
            return RedirectToAction("fetchnews");
        }

        public IActionResult faqs()
        {
            return View();
        }

        [HttpPost]
        public IActionResult faqs(faqs faqs)
        {
            _context.tbl_faqs.Add(faqs);
            _context.SaveChanges();
            return View();
        }

        public IActionResult fetchfaqs(string textsearch)
        {
            var abcadminid = HttpContext.Session.GetString("adminsession");
            if (string.IsNullOrEmpty(abcadminid))
            {
                return RedirectToAction("login");
            }

            List<faqs> faqs = new List<faqs>();
            if (string.IsNullOrEmpty(textsearch))
            {
                faqs = _context.tbl_faqs.ToList();
            }
            else
            {
                faqs = _context.tbl_faqs.FromSqlInterpolated($"select * from tbl_faqs where faqs_id LIKE {textsearch} OR faqs_question LIKE {textsearch} OR faqs_answer LIKE {textsearch}").ToList();
            }
            return View(faqs);
        }

        public IActionResult faqsupdate(int id)
        {
            return View(_context.tbl_faqs.Find(id));
        }

        [HttpPost]
        public IActionResult faqsupdate(faqs faqs)
        {
            _context.tbl_faqs.Update(faqs);
            _context.SaveChanges();
            return RedirectToAction("fetchfaqs");
        }

        public IActionResult faqsdelete(int id)
        {
            var deletefaqsid = _context.tbl_faqs.Find(id);
            _context.tbl_faqs.Remove(deletefaqsid);
            _context.SaveChanges();
            return RedirectToAction("fetchfaqs");
        }

        public IActionResult fetchcontact(string textsearch)
        {
            var abcadminid = HttpContext.Session.GetString("adminsession");
            if (string.IsNullOrEmpty(abcadminid))
            {
                return RedirectToAction("login");
            }

            List<Contact> contact = new List<Contact>();
            if (string.IsNullOrEmpty(textsearch))
            {
                contact = _context.tbl_contact.ToList();
            }
            else
            {
                contact = _context.tbl_contact.FromSqlInterpolated($"select * from tbl_contact where contact_id LIKE {textsearch} OR contact_name LIKE {textsearch} OR contact_email LIKE {textsearch} OR contact_phone LIKE {textsearch} OR contact_city LIKE {textsearch} OR contact_message LIKE {textsearch}").ToList();
            }
            return View(contact);
        }

        public IActionResult contactdelete(int id)
        {
            var deletecontactid = _context.tbl_contact.Find(id);
            _context.tbl_contact.Remove(deletecontactid);
            _context.SaveChanges();
            return RedirectToAction("fetchcontact");
        }

        public IActionResult fetchfeedback(string textsearch)
        {
            var abcadminid = HttpContext.Session.GetString("adminsession");
            if (string.IsNullOrEmpty(abcadminid))
            {
                return RedirectToAction("login");
            }

            List<feedback> feedback = new List<feedback>();
            if (string.IsNullOrEmpty(textsearch))
            {
                feedback = _context.tbl_feedback.ToList();
            }
            else
            {
                feedback = _context.tbl_feedback.FromSqlInterpolated($"select * from tbl_feedback where feedback_id LIKE {textsearch} OR feedback_name LIKE {textsearch} OR feedback_message LIKE {textsearch}").ToList();
            }
            return View(feedback);
        }

        public IActionResult feedbackdelete(int id)
        {
            var deletefeedbackid = _context.tbl_feedback.Find(id);
            _context.tbl_feedback.Remove(deletefeedbackid);
            _context.SaveChanges();
            return RedirectToAction("fetchfeedback");
        }

        public IActionResult insurancepolicy()
        {
            List<PolicyType> policytype = _context.tbl_policytype.ToList();
            ViewData["policytype"] = policytype;
            List<TermPlanYearly> termplanyearly = _context.tbl_termplanyearly.ToList();
            ViewData["termplanyearly"] = termplanyearly;

            return View();
        }

        [HttpPost]
        public IActionResult insurancepolicy(InsurancePolicy insurancepolicy, IFormFile insurancepolicy_image)
        {
            string insurancepolicyimagepath = Path.GetFileName(insurancepolicy_image.FileName);
            string ippath = Path.Combine(_env.WebRootPath, "insurancepolicy_images", insurancepolicyimagepath);
            FileStream ip = new FileStream(ippath, FileMode.Create);
            insurancepolicy_image.CopyTo(ip);
            insurancepolicy.insurancepolicy_image = insurancepolicyimagepath;
            _context.tbl_insurancepolicy.Add(insurancepolicy);
            _context.SaveChanges();
            return RedirectToAction("insurancepolicy");
        }

        public IActionResult fetchinsurancepolicy(string textsearch)
        {
            List<PolicyType> policytype = _context.tbl_policytype.ToList();
            ViewData["policytype"] = policytype;
            List<TermPlanYearly> termplanyearly = _context.tbl_termplanyearly.ToList();
            ViewData["termplanyearly"] = termplanyearly;
            var abcadminid = HttpContext.Session.GetString("adminsession");
            if (string.IsNullOrEmpty(abcadminid))
            {
                return RedirectToAction("login");
            }

            List<InsurancePolicy> insurancepolicy = new List<InsurancePolicy>();
            if (string.IsNullOrEmpty(textsearch))
            {
                insurancepolicy = _context.tbl_insurancepolicy.ToList();
            }
            else
            {
                insurancepolicy = _context.tbl_insurancepolicy.FromSqlInterpolated($"select * from tbl_insurancepolicy where insurancepolicy_id LIKE {textsearch} OR insurancepolicy_name LIKE {textsearch} OR insurancepolicy_description LIKE {textsearch} OR insurancepolicy_premiumamount LIKE {textsearch} OR insurancepolicy_covergeamount LIKE {textsearch} OR policytype_id LIKE {textsearch} OR termplanyearly_id LIKE {textsearch}").ToList();
            }
            return View(insurancepolicy);
        }

        public IActionResult insurancepolicydetails(int id)
        {
            return View(_context.tbl_insurancepolicy.Include(pt => pt.PolicyType).Include(tpy => tpy.TermPlanYearly).FirstOrDefault(ip => ip.insurancepolicy_id == id));
        }

        public IActionResult insurancepolicyupdate(int id)
        {
            List<PolicyType> policytype = _context.tbl_policytype.ToList();
            ViewData["policytype"] = policytype;
            List<TermPlanYearly> termplanyearly = _context.tbl_termplanyearly.ToList();
            ViewData["termplanyearly"] = termplanyearly;
            var insurancePolicy = _context.tbl_insurancepolicy.Find(id);
            return View(insurancePolicy);
        }

        [HttpPost]
        public IActionResult insurancepolicyupdate(InsurancePolicy insurancepolicy, IFormFile insurancepolicy_image)
        {
            // Get the existing insurance policy from the database
            var existingPolicy = _context.tbl_insurancepolicy.Find(insurancepolicy.insurancepolicy_id);

            if (existingPolicy == null)
            {
                // Return an error if the policy doesn't exist
                return NotFound();
            }

            // Update fields only if they are provided (non-null)
            if (!string.IsNullOrEmpty(insurancepolicy.insurancepolicy_name))
            {
                existingPolicy.insurancepolicy_name = insurancepolicy.insurancepolicy_name;
            }

            if (!string.IsNullOrEmpty(insurancepolicy.insurancepolicy_description))
            {
                existingPolicy.insurancepolicy_description = insurancepolicy.insurancepolicy_description;
            }

            if (!string.IsNullOrEmpty(insurancepolicy.insurancepolicy_premiumamount))
            {
                existingPolicy.insurancepolicy_premiumamount = insurancepolicy.insurancepolicy_premiumamount;
            }

            if (!string.IsNullOrEmpty(insurancepolicy.insurancepolicy_covergeamount))
            {
                existingPolicy.insurancepolicy_covergeamount = insurancepolicy.insurancepolicy_covergeamount;
            }

            // Update foreign key references only if they are selected (non-null)
            if (insurancepolicy.policytype_id > 0)
            {
                existingPolicy.policytype_id = insurancepolicy.policytype_id;
            }

            if (insurancepolicy.termplanyearly_id > 0)
            {
                existingPolicy.termplanyearly_id = insurancepolicy.termplanyearly_id;
            }

            // Handle the image upload (only if a new image is uploaded)
            if (insurancepolicy_image != null)
            {
                string insurancepolicyimagepath = Path.GetFileName(insurancepolicy_image.FileName);
                string ippath = Path.Combine(_env.WebRootPath, "insurancepolicy_images", insurancepolicyimagepath);

                // Save the new image file
                using (FileStream ip = new FileStream(ippath, FileMode.Create))
                {
                    insurancepolicy_image.CopyTo(ip);
                }

                // Update the image path in the database
                existingPolicy.insurancepolicy_image = insurancepolicyimagepath;
            }

            // Save the changes in the database
            _context.tbl_insurancepolicy.Update(existingPolicy);
            _context.SaveChanges();

            // Redirect to the policy list page or wherever you want after updating
            return RedirectToAction("fetchinsurancepolicy");
        }


        public IActionResult insurancepolicydelete(int id)
        {
            var deleteinsurancepolicyid = _context.tbl_insurancepolicy.Find(id);
            _context.tbl_insurancepolicy.Remove(deleteinsurancepolicyid);
            _context.SaveChanges();
            return RedirectToAction("fetchinsurancepolicy");
        }

        [HttpGet]
        public IActionResult fetchclaim(string textsearch)
        {
            var abcadminid = HttpContext.Session.GetString("adminsession");
            if (string.IsNullOrEmpty(abcadminid))
            {
                return RedirectToAction("login");
            }

            List<Claim> claim = new List<Claim>();
            if(string.IsNullOrEmpty(textsearch))
            {
               claim = _context.tbl_claim.ToList();
            }
            else
            {
                claim = _context.tbl_claim.FromSqlInterpolated($"select * from tbl_claim where claim_username LIKE {textsearch} OR claim_description LIKE {textsearch} OR claim_userphone LIKE {textsearch} OR claim_userpolicynumber LIKE {textsearch} OR claim_useremail LIKE {textsearch} OR claim_id LIKE {textsearch} OR claim_requestid LIKE {textsearch}").ToList();
            }
            return View(claim);
        }

        public IActionResult claimdetails(int id)
        {
            return View(_context.tbl_claim.FirstOrDefault(c => c.claim_id == id));
        }

        public IActionResult claimdelete(int id)
        {
            var deleteclaimid = _context.tbl_claim.Find(id);
            _context.tbl_claim.Remove(deleteclaimid);
            _context.SaveChanges();
            return RedirectToAction("fetchclaim");
        }

        public IActionResult fetchloan(string textsearch)
        {
            var abcadminid = HttpContext.Session.GetString("adminsession");
            if (string.IsNullOrEmpty(abcadminid))
            {
                return RedirectToAction("login");
            }

            List<Loan> loan = new List<Loan>();
            if (string.IsNullOrEmpty(textsearch))
            {
                loan = _context.tbl_loan.ToList();
            }
            else
            {
                loan = _context.tbl_loan.FromSqlInterpolated($"select * from tbl_loan where loan_id LIKE {textsearch} OR loan_requestid LIKE {textsearch} OR loan_username LIKE {textsearch} OR loan_usercnicnumber LIKE {textsearch} OR loan_userdateofbirth LIKE {textsearch} OR loan_userphonenumber LIKE {textsearch} OR loan_useremail LIKE {textsearch} OR loan_usercity LIKE {textsearch} OR loan_usersector LIKE {textsearch} OR loan_userorganizationname LIKE {textsearch} OR loan_usermontlynetincome LIKE {textsearch} OR loan_userloanamount LIKE {textsearch} OR loan_desiredloanrepaymentperiod LIKE {textsearch}").ToList();
            }
            return View(loan);
        }

        public IActionResult loandetails(int id)
        {
            return View(_context.tbl_loan.FirstOrDefault(l => l.loan_id == id));
        }

        public IActionResult loandelete(int id)
        {
            var deleteloanid = _context.tbl_loan.Find(id);
            _context.tbl_loan.Remove(deleteloanid);
            _context.SaveChanges();
            return RedirectToAction("fetchloan");
        }

        public IActionResult fetchuserpolicy(string textsearch)
        {
            var abcadminid = HttpContext.Session.GetString("adminsession");
            if (string.IsNullOrEmpty(abcadminid))
            {
                return RedirectToAction("login");
            }

            List<UserPolicy> userpolicy = new List<UserPolicy>();
            if (string.IsNullOrEmpty(textsearch))
            {
                userpolicy = _context.tbl_userpolicy.ToList();
            }
            else
            {
                userpolicy = _context.tbl_userpolicy.FromSqlInterpolated($"select * from tbl_userpolicy where userpolicy_id LIKE {textsearch} OR policyID LIKE {textsearch} OR userpolicy_cnicnumber LIKE {textsearch} OR userpolicy_cnicissuancedate LIKE {textsearch} OR userpolicy_name LIKE {textsearch} OR userpolicy_dateofbirth LIKE {textsearch} OR userpolicy_fatherhusbandname LIKE {textsearch} OR userpolicy_gender LIKE {textsearch} OR userpolicy_mobilenumber LIKE {textsearch} OR userpolicy_city LIKE {textsearch} OR userpolicy_emailaddress LIKE {textsearch} OR userpolicy_sourceofincome LIKE {textsearch} OR userpolicy_organizationname LIKE {textsearch} OR userpolicy_organizationsector LIKE {textsearch} OR userpolicy_monthlynetincome LIKE {textsearch} OR userpolicy_residentialaddress LIKE {textsearch} OR userpolicy_insurancepolicyname LIKE {textsearch} OR userpolicy_termplan LIKE {textsearch} OR userpolicy_startdate LIKE {textsearch}").ToList();
            }
            return View(userpolicy);
        }

        public IActionResult userpolicydetails(int id)
        {
            return View(_context.tbl_userpolicy.FirstOrDefault(up => up.userpolicy_id == id));
        }

        public IActionResult userpolicydelete(int id)
        {
            var deleteuserpolicyid = _context.tbl_userpolicy.Find(id);
            _context.tbl_userpolicy.Remove(deleteuserpolicyid);
            _context.SaveChanges();
            return RedirectToAction("fetchuserpolicy");
        }

        public IActionResult fetchpremium(string textsearch)
        {
            var abcadminid = HttpContext.Session.GetString("adminsession");
            if (string.IsNullOrEmpty(abcadminid))
            {
                return RedirectToAction("login");
            }

            List<Preminuim> premium = new List<Preminuim>();
            if (string.IsNullOrEmpty(textsearch))
            {
                premium = _context.tbl_pre.ToList();
            }
            else
            {
                premium = _context.tbl_pre.FromSqlInterpolated($"select * from tbl_pre where pre_id LIKE {textsearch} OR prolicy_type LIKE {textsearch} OR gender LIKE {textsearch} OR age LIKE {textsearch} OR sum_assured LIKE {textsearch} OR premium_pay_mode LIKE {textsearch} OR calculated_premium LIKE {textsearch}").ToList();
            }
            return View(premium);
        }

        public IActionResult premiumdelete(int id)
        {
            var deletepremiumid = _context.tbl_pre.Find(id);
            _context.tbl_pre.Remove(deletepremiumid);
            _context.SaveChanges();
            return RedirectToAction("fetchpremium");
        }

        public IActionResult fetchemi(string textsearch)
        {
            var abcadminid = HttpContext.Session.GetString("adminsession");
            if (string.IsNullOrEmpty(abcadminid))
            {
                return RedirectToAction("login");
            }

            List<EMI> emi = new List<EMI>();
            if (string.IsNullOrEmpty(textsearch))
            {
                emi = _context.tbl_emi.ToList();
            }
            else
            {
                emi = _context.tbl_emi.FromSqlInterpolated($"select * from tbl_emi where emi_id LIKE {textsearch} OR principal LIKE {textsearch} OR rate_of_interest LIKE {textsearch} OR tenure LIKE {textsearch} OR calculated_emi LIKE {textsearch}").ToList();
            }
            return View(emi);
        }

        public IActionResult emidelete(int id)
        {
            var deleteemiid = _context.tbl_emi.Find(id);
            _context.tbl_emi.Remove(deleteemiid);
            _context.SaveChanges();
            return RedirectToAction("fetchemi");
        }

        public IActionResult fetchpayment(string textsearch)
        {
            var abcadminid = HttpContext.Session.GetString("adminsession");
            if (string.IsNullOrEmpty(abcadminid))
            {
                return RedirectToAction("login");
            }

            List<Payment> payment = new List<Payment>();
            if (string.IsNullOrEmpty(textsearch))
            {
                payment = _context.tbl_payment.ToList();
            }
            else
            {
                payment = _context.tbl_payment.FromSqlInterpolated($"select * from tbl_payment where payment_id LIKE {textsearch} OR TransactionID LIKE {textsearch} OR FullName LIKE {textsearch} OR Email LIKE {textsearch} OR Address LIKE {textsearch} OR City LIKE {textsearch} OR Country LIKE {textsearch} OR ZipCode LIKE {textsearch} OR NameOnCard LIKE {textsearch} OR CardNumber LIKE {textsearch} OR ExpiryDate LIKE {textsearch} OR CVV LIKE {textsearch} OR Amount LIKE {textsearch}").ToList();
            }
            return View(payment);
        }

        public IActionResult paymentdetails(int id)
        {
            return View(_context.tbl_payment.FirstOrDefault(p => p.payment_id == id));
        }

        public IActionResult paymentdelete(int id)
        {
            var deletepaymentid = _context.tbl_payment.Find(id);
            _context.tbl_payment.Remove(deletepaymentid);
            _context.SaveChanges();
            return RedirectToAction("fetchpayment");
        }

    }
}
