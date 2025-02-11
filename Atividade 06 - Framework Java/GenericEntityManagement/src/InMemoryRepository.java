import java.util.*;

public class InMemoryRepository<T> implements CrudRepository<T> {
    private final List<T> storage = new ArrayList<>();

    @Override
    public void save(T entity) {
        storage.add(entity);
    }

    @Override
    public T findById(int id) {
        if (id >= 0 && id < storage.size()) {
            return storage.get(id);
        }
        return null;
    }

    @Override
    public void update(T entity) {
        int index = storage.indexOf(entity);
        storage.set(index, entity);
    }

    @Override
    public void delete(int id) {
        if (id >= 0 && id < storage.size()) {
            storage.remove(id);
        }
    }

    @Override
    public List<T> findAll() {
        return new ArrayList<>(storage);
    }
}