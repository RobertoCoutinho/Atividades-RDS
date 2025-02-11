//TIP To <b>Run</b> code, press <shortcut actionId="Run"/> or
// click the <icon src="AllIcons.Actions.Execute"/> icon in the gutter.
public class Main {
    public static void main(String[] args) {
        InMemoryRepository<Produto> produtoRepo = new InMemoryRepository<>();
        Produto p1 = new Produto("Laptop", 3000.0);
        Produto p2 = new Produto("Mouse", 50.0);
        produtoRepo.save(p1);
        produtoRepo.save(p2);
        System.out.println("Lista de Produtos (em memoria):");
        for (Produto p : produtoRepo.findAll()) {
            System.out.println(p);
        }

        //-----------------------------------------------------------------------------------------

        InFileRepository<Produto> fileRepo = new InFileRepository<>("produtos.dat");
        fileRepo.save(p1);
        fileRepo.save(p2);

        System.out.println("Lista de Produtos (Arquivo):");
        for (Produto p : fileRepo.findAll()) {
            System.out.println(p);
        }
    }
}