using Microsoft.EntityFrameworkCore;

using var db = new GoalTrackingContext();
db.Database.Migrate();
db.Database.EnsureCreated();
