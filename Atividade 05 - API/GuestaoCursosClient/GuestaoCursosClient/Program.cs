using System.Net.Http.Json;
using GuestaoCursosClient.Entities;

class Program
{
    static async Task Main(string[] args)
    {
        var UrlBase = "https://localhost:44338";
        using var httpClient = new HttpClient { BaseAddress = new Uri(UrlBase) };

        while (true)
        {
            Console.WriteLine("Menu:");
            Console.WriteLine("1. Listar todos os cursos");
            Console.WriteLine("2. Buscar curso pelo ID");
            Console.WriteLine("3. Adicionar novo curso");
            Console.WriteLine("4. Atualizar curso");
            Console.WriteLine("5. Excluir curso");
            Console.WriteLine("0. Sair");

            var option = Console.ReadLine();

            switch (option)
            {
                case "1":
                    await getAllCursos(httpClient);
                    break;
                case "2":
                    await getCursoByID(httpClient);
                    break;
                case "3":
                    await createCurso(httpClient);
                    break;
                case "4":
                    await updateCurso(httpClient);
                    break;
                case "5":
                    await deleteCurso(httpClient);
                    break;
                case "0":
                    return;
                default:
                    Console.WriteLine("Opção inválida!");
                    break;
            }
        }
    }

    static async Task getAllCursos(HttpClient httpClient)
    {
        try
        {
            var cursos = await httpClient.GetFromJsonAsync<List<Curso>>("cursos");
            if (cursos == null || cursos.Count == 0)
            {
                Console.WriteLine("Nenhum curso encontrado.");
                return;
            }

            foreach (var curso in cursos)
            {
                Console.WriteLine($"ID: {curso.Id}, Título: {curso.Titulo}");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Erro: {ex.Message}");
        }
    }

    static async Task getCursoByID(HttpClient httpClient)
    {
        Console.Write("Digite o ID do curso: ");
        if (int.TryParse(Console.ReadLine(), out var id))
        {
            try
            {
                var curso = await httpClient.GetFromJsonAsync<Curso>($"cursos/{id}");
                if (curso == null)
                {
                    Console.WriteLine("Curso não encontrado.");
                    return;
                }

                Console.WriteLine($"\nDetalhes do Curso:\nID: {curso.Id}\nTítulo: {curso.Titulo}\nDescrição: {curso.Descricao}\nCarga Horária: {curso.CargaHoraria}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro: {ex.Message}");
            }
        }
        else
        {
            Console.WriteLine("ID inválido.");
        }
    }

    static async Task createCurso(HttpClient httpClient)
    {
        Console.Write("Título do curso: ");
        var titulo = Console.ReadLine();

        Console.Write("Descrição do curso: ");
        var descricao = Console.ReadLine();

        Console.Write("Carga horária do curso: ");
        if (float.TryParse(Console.ReadLine(), out var cargaHoraria))
        {
            try
            {
                var curso = new Curso { Titulo = titulo, Descricao = descricao, CargaHoraria = cargaHoraria };
                var response = await httpClient.PostAsJsonAsync("cursos", curso);

                Console.WriteLine(response.IsSuccessStatusCode ? "Curso adicionado com sucesso." : $"Erro ao adicionar curso: {response.ReasonPhrase}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro: {ex.Message}");
            }
        }
        else
        {
            Console.WriteLine("Carga horária inválida.");
        }
    }

    static async Task updateCurso(HttpClient httpClient)
    {
        Console.Write("Digite o ID do curso: ");
        if (int.TryParse(Console.ReadLine(), out var id))
        {
            Console.Write("Novo título do curso: ");
            var titulo = Console.ReadLine();

            Console.Write("Nova descrição do curso: ");
            var descricao = Console.ReadLine();

            Console.Write("Nova carga horária do curso: ");
            if (int.TryParse(Console.ReadLine(), out var cargaHoraria))
            {
                try
                {
                    var curso = new Curso { Titulo = titulo, Descricao = descricao, CargaHoraria = cargaHoraria };
                    var response = await httpClient.PutAsJsonAsync($"cursos/{id}", curso);

                    Console.WriteLine(response.IsSuccessStatusCode ? "Curso atualizado com sucesso." : $"Erro ao atualizar curso: {response.ReasonPhrase}");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Erro: {ex.Message}");
                }
            }
            else
            {
                Console.WriteLine("Carga horária inválida.");
            }
        }
        else
        {
            Console.WriteLine("ID inválido.");
        }
    }

    static async Task deleteCurso(HttpClient httpClient)
    {
        Console.Write("Digite o ID do curso: ");
        if (int.TryParse(Console.ReadLine(), out var id))
        {
            try
            {
                var response = await httpClient.DeleteAsync($"cursos/{id}");
                Console.WriteLine(response.IsSuccessStatusCode ? "Curso excluído com sucesso." : $"Erro ao excluir curso: {response.ReasonPhrase}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro: {ex.Message}");
            }
        }
        else
        {
            Console.WriteLine("ID inválido.");
        }
    }
}
