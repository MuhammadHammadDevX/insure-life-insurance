using Life_Insurance.Models;
using Microsoft.AspNetCore.Mvc;

namespace Life_Insurance.Controllers
{
    public class UserpanelController : Controller
    {
        private Mycontext _context;
        private IWebHostEnvironment _env;
        public UserpanelController(Mycontext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }

        public IActionResult Index()
        {
            List<InsurancePolicy> insurancepolicy = _context.tbl_insurancepolicy.ToList();
            ViewData["insurancepolicy"] = insurancepolicy;
            List<feedback> feedbacks = _context.tbl_feedback.ToList();
            ViewData["feedbacks"] = feedbacks;
            List<faqs> faqs = _context.tbl_faqs.ToList();
            ViewData["faqs"] = faqs;
            return View();
            
        }

        [HttpPost]
        public IActionResult Index(Contact contact)
        {
            List<InsurancePolicy> insurancepolicy = _context.tbl_insurancepolicy.ToList();
            ViewData["insurancepolicy"] = insurancepolicy;
            List<feedback> feedbacks = _context.tbl_feedback.ToList();
            ViewData["feedbacks"] = feedbacks;
            List<faqs> faqs = _context.tbl_faqs.ToList();
            ViewData["faqs"] = faqs;
            _context.tbl_contact.Add(contact);
            _context.SaveChanges();

            TempData["AppointmentSubmitSuccess"] = "Your appointment request has been submitted. Our team will contact you shortly to confirm the details.";

            return View();
        }
    
        public IActionResult userregister()
        {
            return View();
        }

        [HttpPost]
        public IActionResult userregister(User user, IFormFile user_image)
        {
            string getimgname = Path.GetFileName(user_image.FileName);
            string pathimg = Path.Combine(_env.WebRootPath, "user_images", getimgname);
            FileStream fs = new FileStream(pathimg, FileMode.Create);
            user_image.CopyTo(fs);
            user.user_image = getimgname;
            _context.tbl_users.Add(user);
            _context.SaveChanges();

            TempData["UserRegisterSuccess"] = "You have successfully registered. You can now log in.";

            return RedirectToAction("userlogin");
        }

        public IActionResult userlogin()
        {
            return View();
        }

        [HttpPost]
        public IActionResult userlogin(string user_email, string user_password)
        {
            var record = _context.tbl_users.FirstOrDefault(u => u.user_email == user_email);
            if (record != null && record.user_password == user_password)
            {
                HttpContext.Session.SetString("usersession", record.user_id.ToString());
                return RedirectToAction("Index");

            }
            else
            {
                ViewBag.message = "Incorrect Email or Password";
                return View();
            }
        }
        public IActionResult logout()
        {
            // Clear the session
            HttpContext.Session.Remove("usersession");

            // Redirect to the home page or login page after logout
            return RedirectToAction("Index", "Userpanel");
        }

        public IActionResult forgetpassword()
        {
            return View();
        }

        [HttpPost]

        public IActionResult forgetpassword(string user_email, string user_password)
        {
            var record = _context.tbl_users.FirstOrDefault(u => u.user_email == user_email);
            if(record != null)
            {
                record.user_password = user_password;
                _context.SaveChanges();

                TempData["PasswordChangeSuccess"] = "Your password has been changed successfully.";

                return RedirectToAction("userlogin");
            }
            else
            {
                return View();
            }
        }

        public IActionResult contact()
        {
            return View();
        }

        [HttpPost]
        public IActionResult contact(Contact contact)
        {
            _context.tbl_contact.Add(contact);
            _context.SaveChanges();

            TempData["ContactSubmitSuccess"] = "Your request has been submitted. Our team will get in touch with you shortly.";

            return View();
        }

        public IActionResult allinsurancepolicy()
        {
            List<InsurancePolicy> insurancepolicy = _context.tbl_insurancepolicy.ToList();
            ViewData["insurancepolicy"] = insurancepolicy;
            List<feedback> feedbacks = _context.tbl_feedback.ToList();
            ViewData["feedbacks"] = feedbacks;
            List<faqs> faqs = _context.tbl_faqs.ToList();
            ViewData["faqs"] = faqs;
            return View();
        }

        public IActionResult insurancepolicydetails(int id)
        {
            List<PolicyType> policytype = _context.tbl_policytype.ToList();
            ViewData["policytype"] = policytype;
            List<feedback> feedbacks = _context.tbl_feedback.ToList();
            ViewData["feedbacks"] = feedbacks;
            List<TermPlanYearly> termplanyearly = _context.tbl_termplanyearly.ToList();
            ViewData["termplanyearly"] = termplanyearly;
            List<faqs> faqs = _context.tbl_faqs.ToList();
            ViewData["faqs"] = faqs;
            var insurancepolicydetails = _context.tbl_insurancepolicy.Where(ipd => ipd.insurancepolicy_id == id).ToList();
            return View(insurancepolicydetails);
        }

        public IActionResult allnews()
        {
            return View(_context.tbl_news.ToList());
        }

        public IActionResult allfaqs()
        {
            List<faqs> faqs = _context.tbl_faqs.ToList();
            ViewData["faqs"] = faqs;
            return View();
        }

        public IActionResult claim()
        {
            return View();
        }

        [HttpPost]
        public IActionResult claim(Claim claim, IFormFile claim_image)
        {
            // Generate a random 6-digit Claim Request ID
            var random = new Random();
            claim.claim_requestid = random.Next(100000, 999999);

            // Handle file upload
            string getimgname = Path.GetFileName(claim_image.FileName);
            string pathimg = Path.Combine(_env.WebRootPath, "claim_images", getimgname);
            using (var fs = new FileStream(pathimg, FileMode.Create))
            {
                claim_image.CopyTo(fs);
            }
            claim.claim_image = getimgname;

            // Save to database
            _context.tbl_claim.Add(claim);
            _context.SaveChanges();

            // Add success message with Claim Request ID
            TempData["ClaimRequestSuccess"] = $"Your claim request has been sent successfully. Your Claim Request ID is #{claim.claim_requestid}. Our team will contact you after reviewing the details of your claim.";

            return RedirectToAction("claim");
        }


        public IActionResult loan()
        {
            return View();
        }

        [HttpPost]
        [HttpPost]
        public IActionResult loan(Loan loan)
        {
            // Generate a 6-digit random loan request ID
            Random random = new Random();
            loan.loan_requestid = random.Next(100000, 999999).ToString();

            // Save loan data to the database
            _context.tbl_loan.Add(loan);
            _context.SaveChanges();

            TempData["LoanApplicationSuccess"] = $"Your loan application has been submitted. Your loan request ID is #{loan.loan_requestid}. Our team will contact you after reviewing the details of your application.";

            return View();
        }

        public IActionResult settinguser()
        {
            List<PolicyType> policytype = _context.tbl_policytype.ToList();
            ViewData["policytype"] = policytype;
            List<feedback> feedbacks = _context.tbl_feedback.ToList();
            ViewData["feedbacks"] = feedbacks;
            List<TermPlanYearly> termplanyearly = _context.tbl_termplanyearly.ToList();
            ViewData["termplanyearly"] = termplanyearly;
            List<faqs> faqs = _context.tbl_faqs.ToList();
            ViewData["faqs"] = faqs;

            // Get profileid from session
            var profileid = HttpContext.Session.GetString("usersession");

            if (string.IsNullOrEmpty(profileid) || !int.TryParse(profileid, out int userId))
            {
                // If profileid is null, empty, or not a valid integer, handle the error gracefully
                return RedirectToAction("userlogin"); // Or any appropriate action
            }

            // Fetch the customer based on the parsed customerId
            var us = _context.tbl_users.Where(u => u.user_id == userId).ToList();

            return View(us);
        }

        public IActionResult update(int id)
        {
            List<PolicyType> policytype = _context.tbl_policytype.ToList();
            ViewData["policytype"] = policytype;
            List<feedback> feedbacks = _context.tbl_feedback.ToList();
            ViewData["feedbacks"] = feedbacks;
            List<TermPlanYearly> termplanyearly = _context.tbl_termplanyearly.ToList();
            ViewData["termplanyearly"] = termplanyearly;
            List<faqs> faqs = _context.tbl_faqs.ToList();
            ViewData["faqs"] = faqs;
            return View(_context.tbl_users.Find(id));
        }

        [HttpPost]
        public IActionResult update(User user, IFormFile user_image)
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
            return RedirectToAction("settinguser");

        }

        public IActionResult userPolicy()
        {
            return View();
        }

        [HttpPost]
        public IActionResult userPolicy(UserPolicy userpolicy)
        {
            // Generate a 6-digit random policy ID
            Random random = new Random();
            userpolicy.policyID = random.Next(100000, 999999); // Generates a random 6-digit number

            // Add user policy data to the database, including the policyID
            _context.tbl_userpolicy.Add(userpolicy);
            _context.SaveChanges();

            // Store the success message with the generated policy ID in TempData
            TempData["UserpolicySubmitSuccess"] = $"Your form has been successfully submitted. Thank you for showing interest in purchasing a policy with us. Your policy ID is #{userpolicy.policyID}. Our team will contact you shortly to confirm the policy details. We appreciate your trust!";

            return View();
        }

        public IActionResult feedback()
        {
            List<feedback> feedbacks = _context.tbl_feedback.ToList();
            ViewData["feedbacks"] = feedbacks;
            return View();
        }

        [HttpPost]
        public IActionResult feedback(feedback feedback)
        {
            List<feedback> feedbacks = _context.tbl_feedback.ToList();
            ViewData["feedbacks"] = feedbacks;
            _context.tbl_feedback.Add(feedback);
            _context.SaveChanges();

            TempData["FeedbackSubmitSuccess"] = "Thank you for your valuable feedback! We appreciate your time.";

            return View();
        }

        public IActionResult aboutus()
        {
            return View();
        }

        public IActionResult bookappoinment()
        {
            List<InsurancePolicy> insurancepolicy = _context.tbl_insurancepolicy.ToList();
            ViewData["insurancepolicy"] = insurancepolicy;
            List<feedback> feedbacks = _context.tbl_feedback.ToList();
            ViewData["feedbacks"] = feedbacks;
            List<faqs> faqs = _context.tbl_faqs.ToList();
            ViewData["faqs"] = faqs;
            return View();
        }

        [HttpPost]
        public IActionResult bookappoinment(Contact contact)
        {
            List<InsurancePolicy> insurancepolicy = _context.tbl_insurancepolicy.ToList();
            ViewData["insurancepolicy"] = insurancepolicy;
            List<feedback> feedbacks = _context.tbl_feedback.ToList();
            ViewData["feedbacks"] = feedbacks;
            List<faqs> faqs = _context.tbl_faqs.ToList();
            ViewData["faqs"] = faqs;
            _context.tbl_contact.Add(contact);
            _context.SaveChanges();

            TempData["AppointmentSubmitSuccess"] = "Your appointment request has been submitted. Our team will contact you shortly to confirm the details.";

            return View();
        }

        public IActionResult meetourexperts()
        {
            return View();
        }

        [HttpGet]
        public IActionResult pre_form()
        {
            return View();
        }

        [HttpPost]
        public IActionResult pre_form(Preminuim pre)
        {
            // Base premium amount
            decimal basePremium = 1000m;

            // Determine the payment mode factor
            decimal paymentModeFactor = 0m;
            switch (pre.premium_pay_mode)
            {
                case "Annually":
                    paymentModeFactor = 1m;
                    break;
                case "Half Yearly":
                    paymentModeFactor = 0.6m;
                    break;
                case "Quarterly": // Adding quarterly
                    paymentModeFactor = 0.3m;
                    break;
                case "Monthly":
                    paymentModeFactor = 0.1m;
                    break;
                default:
                    break;
            }

            // Ensure age is valid and multiply it in the premium calculation
            int age = pre.age >= 18 ? pre.age : 18; // Age should be at least 18, if less, default to 18

            // Calculate premium
            decimal calculatedPremium = basePremium * paymentModeFactor * age;

            // Set the calculated premium in the model
            pre.calculated_premium = calculatedPremium;

            // Save to the database
            _context.tbl_pre.Add(pre);
            _context.SaveChanges();

            // Pass calculated premium and model data to the view
            ViewBag.CalculatedPremium = calculatedPremium;

            return View(pre); // Return the model to display user inputs along with the premium
        }

        // GET: Display the EMI form
        public IActionResult emi_form()
        {
            return View();
        }

        // POST: Handle form submission and calculate EMI
        [HttpPost]
        public IActionResult emi_form(EMI emi)
        {
            if (ModelState.IsValid)
            {
                // Constants and input values
                decimal principal = emi.principal;
                decimal rateOfInterest = emi.rate_of_interest / 1200; // Fixed annual rate (11%) converted to monthly fraction
                int tenure = emi.tenure; // Loan tenure in months

                // EMI Calculation Formula
                // EMI = [P x R x (1+R)^N] / [(1+R)^N - 1]
                decimal emiValue;
                if (rateOfInterest > 0)
                {
                    decimal rateFactor = (decimal)Math.Pow((double)(1 + rateOfInterest), tenure);
                    emiValue = (principal * rateOfInterest * rateFactor) / (rateFactor - 1);
                }
                else
                {
                    emiValue = principal / tenure; // If interest rate is zero
                }

                // Set calculated EMI in the model
                emi.calculated_emi = Math.Round(emiValue, 2);

                // Save the EMI details in the database (Assuming _context is your DbContext)
                _context.tbl_emi.Add(emi);
                _context.SaveChanges();

                // Pass calculated EMI to ViewBag for display in the view
                ViewBag.CalculatedEMI = emi.calculated_emi;

                // Return the view with the model to retain user inputs
                return View(emi);
            }

            // Return the same view with validation errors if the model is invalid
            return View(emi);
        }

        public IActionResult payment()
        {
            return View();
        }

        [HttpPost]
        public IActionResult payment(Payment payment)
        {
            // Generate a 6-digit random transaction ID
            Random random = new Random();
            int transactionID = random.Next(100000, 999999); // Generates a random 6-digit number

            // Assign the TransactionID to the payment object
            payment.TransactionID = transactionID;

            // Add payment data to the database (including TransactionID)
            _context.tbl_payment.Add(payment);
            _context.SaveChanges();

            // Store the success message with the transaction ID in TempData
            TempData["PaymentPaySuccess"] = $"Payment Successful! Your transaction ID is #{transactionID}. Please save it for your records. Your receipt will be sent to your email shortly.";

            return View();
        }

    }
}
