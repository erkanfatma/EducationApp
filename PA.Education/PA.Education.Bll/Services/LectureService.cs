using PA.Education.Dal.Models;
using PA.Education.Dal.Repositories;

namespace PA.Education.Bll.Services; 

public class LectureService {
    private LectureRepository _repository;

    public LectureService(LectureRepository repository) {
        _repository = repository;
    }
    
    public IEnumerable<Lecture> GetAllLectures() {
        return _repository.Get();
    }

    public Lecture? GetById(int id) {
        return _repository.GetById(id);
    }

    public Lecture CreateLecture(Lecture lecture) {
        return _repository.Create(lecture);
    }

    public Lecture UpdateLecture(Lecture lecture) {
        return _repository.Update(lecture);
    }

    public bool DeleteLecture(int id) {
        return _repository.Delete(id);
    }
}