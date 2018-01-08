using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebbDejt2.Models;

namespace WebbDejt2.Controllers
{
    public class FriendsController : BaseController
    {
        //
        // SEND: FriendRequest
        [Authorize]
        public ActionResult SendFriendRequest(string toId)
        {
            var Receiver = db.Users.Find(toId);
            var Email = User.Identity.Name;
            var Sender = db.Users.Single(x => x.UserName == Email);

            var newFriend = new Friend(Sender, Receiver);

            Sender.FriendRequestsSent.Add(newFriend);
            Receiver.FriendRequestsReceived.Add(newFriend);

            db.Friends.Add(newFriend);
            db.SaveChanges();
            return RedirectToAction("Profile", "Account", new { username = Receiver.Email }); //Popupp meddelande
        }

        // GET: Friends
        public ActionResult Index()
        {
            var Email = User.Identity.Name;
            var user = db.Users.Single(x => x.UserName == Email);

            var allFriendList = db.Friends.ToList();

            var myFriendList = new List<Friend>();

            foreach (Friend f in allFriendList)
            {
                if ((f.Receiver.Id == user.Id || f.Sender.Id == user.Id))
                {
                    myFriendList.Add(f);
                }
            }

            return View(myFriendList);
        }

        public ActionResult AcceptFriendRequest(string id)
        {
            var friend = db.Friends.Find(id);
            friend.FriendAccepted = true;
            db.Entry(friend).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult CheckFriendRequests()
        {
            int FriendRequests = 0;

            var Email = User.Identity.Name;
            var user = db.Users.Single(x => x.UserName == Email);

            var allFriendList = db.Friends.ToList();

            foreach (Friend f in allFriendList)
            {
                if (f.Receiver.Id == user.Id && f.FriendAccepted == false)
                {
                    FriendRequests = +1;
                }
            }

            return Content(FriendRequests.ToString());
        }

        // GET: Friends/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Friend friend = db.Friends.Find(id);
            if (friend == null)
            {
                return HttpNotFound();
            }
            return View(friend);
        }

        // GET: Friends/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Friends/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "keyId,FriendAccepted")] Friend friend)
        {
            if (ModelState.IsValid)
            {
                db.Friends.Add(friend);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(friend);
        }

        // GET: Friends/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Friend friend = db.Friends.Find(id);
            if (friend == null)
            {
                return HttpNotFound();
            }
            return View(friend);
        }

        // POST: Friends/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "keyId,FriendAccepted")] Friend friend)
        {
            if (ModelState.IsValid)
            {
                db.Entry(friend).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(friend);
        }

        // GET: Friends/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Friend friend = db.Friends.Find(id);
            if (friend == null)
            {
                return HttpNotFound();
            }
            return View(friend);
        }

        // POST: Friends/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Friend friend = db.Friends.Find(id);
            db.Friends.Remove(friend);
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
