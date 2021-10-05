using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using ltap.Models;

namespace ltap.Controllers
{
    public class PersonController : Controller
    {
        //khai bao dbcontext de lam viec voi database
        private LapTrinhQuanLyDBcontext db = new LapTrinhQuanLyDBcontext();

        // GET: Person
        public ActionResult Index()
        {
            //tra ve view index kem theo list danh sach person trong database
            return View(db.Persons.ToList());
        }

        // GET: Person/Details/5
        public ActionResult Details(string id)
        {
            //neu id truyen vao = null thi tra trang badrequest
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //tim kiem person theo id duoc gui len
            Person person = db.Persons.Find(id);
            if (person == null)
            {
                //tra ve trang notfound neu khong tim thay du lieu
                return HttpNotFound();
            }
            //tra ve view kem theo thong tin cua person tim duoc
            return View(person);
        }

        // GET: Person/Create
        public ActionResult Create()
        {
            //tra ve view de cho nguoi dung nhap thong tin  
            return View();
        }

        // POST: Person/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        //qua ly phien lam viec gui cilent va sever
        [ValidateAntiForgeryToken]
        //nhan gia tri cac thuoc tinh tu client gui len
        public ActionResult Create(Person person)
        {
            //neu thoa man rang buoc ve du lieu
            if (ModelState.IsValid)
            {
                //add doi tuong gui len tu pha client vao dbcontext
                db.Persons.Add(person);
                //luu thay doi vao database
                db.SaveChanges();
                //dieu huong ve action index
                return RedirectToAction("Index");
            }
            //giu nguyen view creat kem thong bao loi
            return View(person);
        }

        // GET: Person/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Person person = db.Persons.Find(id);
            if (person == null)
            {
                return HttpNotFound();
            }
            return View(person);
        }

        // POST: Person/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PersonID,PersonName")] Person person)
        {
            if (ModelState.IsValid)
            {
                db.Entry(person).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(person);
        }

        // GET: Person/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Person person = db.Persons.Find(id);
            if (person == null)
            {
                return HttpNotFound();
            }
            return View(person);
        }

        // POST: Person/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Person person = db.Persons.Find(id);
            db.Persons.Remove(person);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
