namespace CommInfo.Migrations
{
    using CommInfo.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<CommInfo.Models.CommInfoContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            ContextKey = "CommInfo.Models.CommInfoContext";
        }

        protected override void Seed(CommInfo.Models.CommInfoContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //

            // From ForumDbInitilizer
            DateTime seedDate = new DateTime(2016, 01, 01);

            // Member Seed
            Member memb001 = new Member { NameFirst = "John", NameLast = "Watson", UserName = "John", Email = "jwatson@test.com" };  // UserName, Email from Identity
            Member memb002 = new Member { NameFirst = "David", NameLast = "Yamamoto", UserName = "David", Email = "bigwavedave@test.com" };
            Member memb003 = new Member { NameFirst = "Carrie", NameLast = "Tam", UserName = "Carrie", Email = "carrietam@test.com" };
            Member memb004 = new Member { NameFirst = "Nani", NameLast = "Kealoha", UserName = "Nani", Email = "nanik@test.com" };

            // Fora seed
            Forum frm001 = new Forum { ForumID = 01, ForumName = "Forum 1" };
            Forum frm002 = new Forum { ForumID = 02, ForumName = "Forum 2" };

            // Thread ("Topics") seed
            Thread trd001 = new Thread { MemberID = 01, Topic = "Aiea Vs. Farrington" };
            Thread trd002 = new Thread { MemberID = 02, Topic = "Surf Hui Planing Meeting" };
            Thread trd003 = new Thread { MemberID = 03, Topic = "Aiea Book Club" };
            Thread trd004 = new Thread { MemberID = 04, Topic = "Kite Club" };

            // Messages seed
            Message msg01 = new Message { MemberID = 01, Date = seedDate, From = "John", Subject = "Did you see the game?", Body = "The Alii trashed the Bulldogs!" };
            Message msg02 = new Message { MemberID = 02, Date = seedDate, From = "David", Subject = "Meeting at Aiea Library this Friday", Body = "We're planning our next surf meet. Anyone want to come?" };
            Message msg03 = new Message { MemberID = 03, Date = seedDate, From = "Carrie", Subject = "Bookclub meeting this week?", Body = "Are we having a meeting this Thursday?" };
            Message msg04 = new Message { MemberID = 04, Date = seedDate, From = "Nani", Subject = "Pearl Harbor Park Picnic", Body = "Bring a kite and the keiki! We have the musubi ready." };

            trd001.Members.Add(memb001);
            trd002.Members.Add(memb002);
            trd003.Members.Add(memb003);
            trd004.Members.Add(memb004);
            trd001.Messages.Add(msg01);
            trd002.Messages.Add(msg02);
            trd003.Messages.Add(msg03);
            trd004.Messages.Add(msg04);
            frm001.Threads.Add(trd001);
            frm001.Threads.Add(trd002);
            frm002.Threads.Add(trd003);
            frm002.Threads.Add(trd004);
            context.Fora.AddOrUpdate(frm002, frm002);
            //context.Fora.AddOrUpdate(frm001);
            //context.Fora.AddOrUpdate(frm002);
            //context.Messages.AddOrUpdate(m => m.Subject, msg01, msg02, msg03, msg04);
            //context.Threads.AddOrUpdate(t => t.Topic, trd001, trd002, trd003, trd004);
            //context.Users.AddOrUpdate(u => u.UserName, memb001, memb002, memb003, memb004);
            //context.Fora.AddOrUpdate(f => f.ForumName, frm001, frm002);


            // runs a debugger in a seperate instance of VisualStudio
            if (System.Diagnostics.Debugger.IsAttached == false)
                System.Diagnostics.Debugger.Launch();

        }
    }
}
