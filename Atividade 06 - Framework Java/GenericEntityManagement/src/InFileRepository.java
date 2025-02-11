import java.io.*;
import java.util.*;
public class InFileRepository<T> implements CrudRepository<T> {
    private final String filename;
    private final List<T> storage = new ArrayList<>();

    public InFileRepository(String filename) {
        this.filename = filename;
        loadFromFile();
    }

    @Override
    public void save(T entity) {
        storage.add(entity);
        saveToFile();
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
        if (index != -1) {
            storage.set(index, entity);
        }
        saveToFile();
    }

    @Override
    public void delete(int id) {
        if (id >= 0 && id < storage.size()) {
            storage.remove(id);
        }
        saveToFile();
    }

    @Override
    public List<T> findAll() {
        return new ArrayList<>(storage);
    }

    private void saveToFile() {
        try (ObjectOutputStream oos = new ObjectOutputStream(new FileOutputStream(filename))) {
            oos.writeObject(storage);
        } catch (IOException e) {
        }
    }

    private void loadFromFile() {
        try (ObjectInputStream ois = new ObjectInputStream(new FileInputStream(filename))) {
            Object obj = ois.readObject();
            if (obj instanceof List) {
                storage.addAll((List<T>) obj);
            }
        } catch (IOException | ClassNotFoundException e) {
        }
    }
}
