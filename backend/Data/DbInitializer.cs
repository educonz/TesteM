using Core.Data.Repository;
using Domain.Usuarios;
using System.Linq;
using TesteMeta.Domain;

namespace Data
{
    public static class DbInitializer
    {
        public static void Seed(IRepositoryGeneric repository)
        {
            if (!repository.ReadOnlyQuery<Usuario>().Any())
            {
                var listaUsuario = new[]
                {
                    new Usuario
                    {
                        UserName = "fornecedor2",
                        Password = "12345"
                    },
                    new Usuario
                    {
                        UserName = "fornecedor1",
                        Password = "12345"
                    },
                    new Usuario
                    {
                        UserName = "fornecedor3",
                        Password = "12345"
                    },
                    new Usuario
                    {
                        UserName = "fornecedor4",
                        Password = "12345"
                    },
                    new Usuario
                    {
                        UserName = "fornecedor5",
                        Password = "12345"
                    },
                    new Usuario
                    {
                        UserName = "fornecedor6",
                        Password = "12345"
                    },
                    new Usuario
                    {
                        UserName = "fornecedor7",
                        Password = "12345"
                    },
                    new Usuario
                    {
                        UserName = "fornecedor8",
                        Password = "12345"
                    }
                };
                foreach (var usuario in listaUsuario)
                    repository.Add(usuario);
                repository.Commit();
            }

            if (!repository.ReadOnlyQuery<Cliente>().Any())
            {
                repository.Add(new Cliente
                {
                    Nome = "Cliente 1",
                    Bairro = "Bairro 1",
                    Cidade = "Cidade 1",
                    Estado = "Estado 1",
                });

                repository.Add(new Cliente
                {
                    Nome = "Cliente 2",
                    Bairro = "Bairro 2",
                    Cidade = "Cidade 2",
                    Estado = "Estado 2",
                });

                repository.Add(new Cliente
                {
                    Nome = "Cliente 3",
                    Bairro = "Bairro 3",
                    Cidade = "Cidade 3",
                    Estado = "Estado 3",
                });

                repository.Add(new Cliente
                {
                    Nome = "Cliente 4",
                    Bairro = "Bairro 4",
                    Cidade = "Cidade 4",
                    Estado = "Estado 4",
                });

                repository.Add(new Cliente
                {
                    Nome = "Cliente 5",
                    Bairro = "Bairro 5",
                    Cidade = "Cidade 5",
                    Estado = "Estado 5",
                });

                repository.Add(new Cliente
                {
                    Nome = "Cliente 6",
                    Bairro = "Bairro 6",
                    Cidade = "Cidade 6",
                    Estado = "Estado 6",
                });

                repository.Add(new Cliente
                {
                    Nome = "Cliente 7",
                    Bairro = "Bairro 7",
                    Cidade = "Cidade 7",
                    Estado = "Estado 7",
                });

                repository.Add(new Cliente
                {
                    Nome = "Cliente 8",
                    Bairro = "Bairro 8",
                    Cidade = "Cidade 8",
                    Estado = "Estado 8",
                });

                repository.Commit();
            }

            if (!repository.ReadOnlyQuery<Fornecedor>().Any())
            {
                var listaFornecedoresUsuarios = repository.ReadOnlyQuery<Usuario>().AsEnumerable();

                repository.Add(new Fornecedor
                {
                    Nome = "Fornecedor 1",
                    IdUsuario = listaFornecedoresUsuarios.FirstOrDefault(x => x.UserName.Equals("fornecedor1")).Id,
                });

                repository.Add(new Fornecedor
                {
                    Nome = "Fornecedor 2",
                    IdUsuario = listaFornecedoresUsuarios.FirstOrDefault(x => x.UserName.Equals("fornecedor2")).Id,
                });

                repository.Add(new Fornecedor
                {
                    Nome = "Fornecedor 3",
                    IdUsuario = listaFornecedoresUsuarios.FirstOrDefault(x => x.UserName.Equals("fornecedor3")).Id,
                });

                repository.Add(new Fornecedor
                {
                    Nome = "Fornecedor 4",
                    IdUsuario = listaFornecedoresUsuarios.FirstOrDefault(x => x.UserName.Equals("fornecedor4")).Id,
                });

                repository.Add(new Fornecedor
                {
                    Nome = "Fornecedor 5",
                    IdUsuario = listaFornecedoresUsuarios.FirstOrDefault(x => x.UserName.Equals("fornecedor5")).Id,
                });

                repository.Add(new Fornecedor
                {
                    Nome = "Fornecedor 6",
                    IdUsuario = listaFornecedoresUsuarios.FirstOrDefault(x => x.UserName.Equals("fornecedor6")).Id,
                });

                repository.Add(new Fornecedor
                {
                    Nome = "Fornecedor 7",
                    IdUsuario = listaFornecedoresUsuarios.FirstOrDefault(x => x.UserName.Equals("fornecedor7")).Id,
                });

                repository.Add(new Fornecedor
                {
                    Nome = "Fornecedor 8",
                    IdUsuario = listaFornecedoresUsuarios.FirstOrDefault(x => x.UserName.Equals("fornecedor8")).Id,
                });

                repository.Commit();
            }
        }
    }
}

