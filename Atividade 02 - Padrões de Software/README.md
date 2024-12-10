# Padrão Iterator

Este exemplo demonstra como a interface `IEnumerable` em C# pode simplificar a iteração sobre diferentes tipos de coleções (como arrays e listas) com um único método genérico. Em vez de criar funções separadas para cada tipo de coleção, usamos uma função genérica que trabalha com qualquer coleção que implemente `IEnumerable<T>`. Isso elimina a necessidade de código redundante e facilita o uso de uma lógica de iteração unificada para múltiplos tipos de coleções.

Ao implementar essa solução, podemos acessar os elementos das coleções de forma padronizada, garantindo maior flexibilidade e manutenção do código.