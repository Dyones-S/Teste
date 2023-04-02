<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="Inscritos.aspx.vb" Inherits="Inscritos" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
 
   
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    <script type="text/javascript">
        function mostrarMensagem() {
            Swal.fire(
                'Sucesso!',
                'Inscrito cadastrado com sucesso!',
                'success'
            )
        }
        var parametro = '<%= HttpContext.Current.Session("statusAdd") %>';
             <% Session.Remove("statusAdd") %>

             var parametro2 = '<%= HttpContext.Current.Session("statusUpdate") %>';
             <% Session.Remove("statusUpdate") %>

        if (parametro) {
            Swal.fire("Sucesso", "Inscrito cadastrado com sucesso!", "success");
        }
        if (parametro2) {
            Swal.fire("Sucesso", "Inscrito editado com sucesso!", "success");
        }
    </script>

    <section class="Inscritos">
<div class="modal fade" id="modalInscritos" tabindex="-1" aria-labelledby="exampleModalLabel" aria-hidden="true">
    <div class="modal-dialog">
    <div class="modal-content">
        <div class="modal-header">
        <h1 class="modal-title fs-5" id="exampleModalLabel"><span class="cadastrarE">Cadastrar</span> Inscrito</h1>
        <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
        </div>
        <div class="modal-body">
            <form id="formInscritos" runat="server">
                <input type="hidden" name="tipo" value="0" id="tipo" />
                <div class="row">
                    <div class="col-md-6 mb-3">
                        <label for="nome" class="form-label">Nome</label>
                        <input type="text" class="form-control" name="nome" required id="nome"
                            placeholder="Seu nome" />
                    </div>
                    <div class="col-md-6 mb-3">
                        <label for="nasc" class="form-label">Data de nascimento</label>
                        <input type="date" class="form-control" name="nasc" required id="nasc" />
                    </div>
                    <div class="col-md-6 mb-3">
                        <label for="email" class="form-label">E-mail</label>
                        <input type="text" class="form-control" name="email" required id="email"
                            placeholder="Seu email" />
                    </div>
                    <div class="col-md-6 mb-3">
                        <label for="instagram" class="form-label">Instagram</label>
                        <input type="text" class="form-control" name="instagram" required id="instagram"
                            placeholder="Seu @ no instagram" />
                    </div>
                </div>


                <button type="button" class="btn btn-secondary" data-bs-dismiss="modal">Fechar</button>
                <asp:Button runat="server" ID="btnAction" Class="btn btn-primary cadastrarE" Text="Cadastrar"/>
            </form>
        </div>
    </div>
    </div>
</div>
        <div class="container">
            <div class="glass">
                <div class="top_info">
                    <h2 class="page_title">Inscritos</h2>
                    <a data-bs-toggle="modal" data-bs-target="#modalInscritos"><i class="fa-regular fa-plus"></i></a>
                </div>                
                
                <table id="Inscritos" class="table table-striped w-100">
                    <thead>
                        <tr>
                            <th>ID</th>
                            <th>Nome</th>
                            <th>Data de nascimento</th>
                            <th>E-mail</th>
                            <th>Endereço Instagram</th>
                            <th>Ações</th>
                        </tr>
                    </thead>
                    <tbody id="tabela_inscritos" runat="server">
                       <!-- <tr>
                            <th>01</th>
                            <th>Dyones</th>
                            <th>13/02/2001</th>
                            <th>dyones@gmail.com</th>
                            <th>@Dyones</th>
                            <td class="acoes">
                                <a href="#" class="editar" title="Editar"><i class="fa-regular fa-pen-to-square"></i></a>
                                <a href="#" class="excluir" title="Excluir"><i class="fa-regular fa-x"></i></a>
                            </td>
                        </tr> -->
                    </tbody>
                    <tfoot>
                        <tr>
                            <th>ID</th>
                            <th>Nome</th>
                            <th>Data de nascimento</th>
                            <th>E-mail</th>
                            <th>Endereço Instagram</th>
                            <th>Ações</th>
                        </tr>
                    </tfoot>
                </table>
            </div>
        </div>
    </section>
    <script>
        $(document).ready(function () {
            $('#Inscritos').DataTable({
                "language": {
                    "url": "https://cdn.datatables.net/plug-ins/1.10.25/i18n/Portuguese-Brasil.json"
                },

            });
        });

        $('.editar').click(function () {
            // obter a linha da tabela onde o botão foi clicado
            var linha = $(this).closest('tr');
            $('#modalInscritos').modal('show');

            $('.cadastrarE').text('Atualizar');
            $('.cadastrarE').val('Atualizar');


            // recuperar os dados na linha com as classes correspondentes
            var id = linha.find('.id').text();
            var nome = linha.find('.nome').text();
            var email = linha.find('.email').text();
            var instagram = linha.find('.instagram').text();
            var data = linha.find('.data').text();

            // obter a data no formato "dd/mm/aaaa"
            var data = linha.find('.data').text();

            // dividir a string em dia, mês e ano
            var partesData = data.split('/');
            var dia = partesData[0];
            var mes = partesData[1];
            var ano = partesData[2];

            // concatenar os valores no formato "aaaa-mm-dd"
            var dataFormatada = ano + "-" + mes + "-" + dia;


            // preencher os campos do formulário com esses dados
            $('#tipo').val(id);
            $('#nome').val(nome);
            $('#nasc').val(dataFormatada);
            $('#email').val(email);
            $('#instagram').val(instagram);

        });

        $('#modalInscritos').on('hidden.bs.modal', function () {
            // redefinir todos os campos do formulário para seus valores padrão
            $('#tipo').val(0);
            $('#formInscritos')[0].reset();
            $('.cadastrarE').text('Cadastrar');
            $('.cadastrarE').val('Cadastrar');
        });

        $('.excluir').click(function () {

                Swal.fire({
                    title: 'Tem certeza?',
                    text: "Você não poderá reverter isso!",
                    icon: 'warning',
                    showCancelButton: true,
                    confirmButtonColor: '#3085d6',
                    cancelButtonColor: '#d33',
                    confirmButtonText: 'Sim, deletar!',
                    cancelButtonText: 'Cancelar'
                }).then((result) => {
                    if (result.isConfirmed) {

                        var linha = $(this).closest('tr');
                        var id = linha.find('.id').text();

                        $.ajax({
                            url: 'Request.aspx',
                            type: 'POST',
                            data: { 'acao': 'deletarInscrito', 'id' : id },
                            dataType: 'json',
                            success: function (response) {
                                console.log(response)
                                if (response.status === 'success') {
                                    Swal.fire(
                                        'Deletado!',
                                        'O item foi deletado.',
                                        'success'
                                    )
                                    setTimeout(function () {
                                        window.location.reload();
                                    }, 2000);
                                } else {
                                    // Ocorreu um erro
                                    console.error(response.message);
                                }
                            },
                            error: function () {
                                // Erro na solicitação AJAX
                                console.error('Erro na solicitação AJAX');
                            }
                        });
                    }
                });
            
        })
    </script>
</asp:Content>

