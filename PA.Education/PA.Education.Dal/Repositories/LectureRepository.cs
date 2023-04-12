using PA.Education.Dal.Models;

namespace PA.Education.Dal.Repositories; 

public class LectureRepository {
    private readonly EducationDbContext _context;

    public LectureRepository(EducationDbContext context) {
        _context = context;
    }

    public IEnumerable<Lecture> Get() {
        return _context.Lectures.Where(r => r.Status == true).ToList();
    }

    public Lecture? GetById(int id) {
        try { 
            return _context.Lectures.Find(id);
        }
        catch (Exception e) {
            throw new Exception(e.Message);
        }
        
    }

    public Lecture Create(Lecture lecture) {
        try { 
            lecture.Status = true;
            lecture.CreatedDate = DateTime.Now;
            _context.Lectures.Add(lecture);
            _context.SaveChanges();

            return lecture;
        }
        catch (Exception e) {
            throw new Exception(e.Message);
        }
    }

    public Lecture Update(Lecture lecture) {
        try {
            var editLecture = _context.Lectures.Find(lecture.Id);
            if (editLecture == null) {
                throw new Exception("Not found.");
            }
            editLecture.Title = lecture.Title;
            editLecture.Description = lecture.Description;
            editLecture.Status = lecture.Status;
            _context.SaveChanges();
            return editLecture;
        }
        catch (Exception e) {
            throw new Exception(e.Message);
        }
        
    }

    public bool Delete(int id) {
        try {
            var editLecture = _context.Lectures.Find(id);
            if (editLecture == null) {
                throw new Exception("Not found.");
            }
            editLecture.Status = false;
            _context.SaveChanges();
            return true;
        }
        catch (Exception e) {
            throw new Exception(e.Message);
        }
       
        
    }
}
