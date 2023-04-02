<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="Lives.aspx.vb" Inherits="Lives" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server"> 

    <script type="text/javascript">
        function mostrarMensagem() {
            Swal.fire(
                'Sucesso!',
                'Live cadastrada com sucesso!',
                'success'
            )
        }
        var parametro = '<%= HttpContext.Current.Session("statusAdd") %>';
             <% Session.Remove("statusAdd") %>

             var parametro2 = '<%= HttpContext.Current.Session("statusUpdate") %>';
             <% Session.Remove("statusUpdate") %>

        if (parametro) {
            Swal.fire("Sucesso", "Live cadastrada com sucesso!", "success");
        }
        if (parametro2) {
            Swal.fire("Sucesso", "Live editada com sucesso!", "success");
        }
    </script>

    <section class="lives">
<div class="modal fade" id="modalLives" tabindex="-1" aria-labelledby="exampleModalLabel" aria-hidden="true">
    <div class="modal-dialog">
    <div class="modal-content">
        <div class="modal-header">
        <h1 class="modal-title fs-5" id="exampleModalLabel"><span class="cadastrarE">Cadastrar</span> Live</h1>
        <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
        </div>
        <div class="modal-body">
            <form id="formLives" runat="server">
                <input type="hidden" name="tipo" value="0" id="tipo" />
                <div class="row">
                    <div class="col-md-6 mb-3">
                        <label for="nome" class="form-label">Nome da live</label>
                        <input type="text" class="form-control" name="nome" required id="nome"
                            placeholder="Seu nome" />
                    </div>
                    <div class="col-md-6 mb-3">
                        <label for="desc" class="form-label">Descrição</label>
                        <input type="text" class="form-control" name="desc" required id="desc" />
                    </div>
                    <div class="col-md-6 mb-3">
                        <label for="inst" class="form-label">Instrutor</label>
                        <select class="form-control" name="inst" required id="inst"  runat="server" >
                            <option value="">Selecione um instrutor</option>
                        </select>
                    </div>
                    <div class="col-md-6 mb-3">
                        <label for="data" class="form-label">Data de Inicio</label>
                        <input type="datetime-local" class="form-control" name="data" required id="data" />
                    </div>
                    <div class="col-md-6 mb-3">
                        <label for="duracao" class="form-label">Duração</label>
                        <input type="number" class="form-control" name="duracao" required id="duracao"
                            placeholder="Duracao em Minutos" />
                    </div>
                    <div class="col-md-6 mb-3">
                        <label for="valor" class="form-label">Valor</label>
                        <input type="text" class="form-control" name="valor" required id="valor"
                            placeholder="Valor" />
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
                    <h2 class="page_title">Lives</h2>
                    <a data-bs-toggle="modal" data-bs-target="#modalLives"><i class="fa-regular fa-plus"></i></a>
                </div>                
                
                <table id="lives" class="table table-striped w-100">
                    <thead>
                        <tr>
                            <th>ID</th>
                            <th>Live</th>
                            <th>Descrição</th>
                            <th>Instrutor</th>
                            <th>Data e Hora de Início</th>
                            <th>Duracao</th>
                            <th>Valor Inscrição</th>
                            <th>Ações</th>
                        </tr>
                    </thead>
                    <tbody id="tabela_lives" runat="server">
                    </tbody>
                    <tfoot>
                        <tr>
                            <th>Live</th>
                            <th>Descrição</th>
                            <th>Instrutor</th>
                            <th>Data e Hora de Início</th>
                            <th>Duracao</th>
                            <th>Valor Inscrição</th>
                            <th>Ações</th>
                        </tr>
                    </tfoot>
                </table>
            </div>
        </div>
    </section>
    <script>
        $(document).ready(function () {
            $('#lives').DataTable({
                "language": {
                    "url": "https://cdn.datatables.net/plug-ins/1.10.25/i18n/Portuguese-Brasil.json"
                },

            });
        });

        $('.editar').click(function () {
            console.log('tessre')
            // obter a linha da tabela onde o botão foi clicado
            var linha = $(this).closest('tr');
            $('#modalLives').modal('show');

            $('.cadastrarE').text('Atualizar');
            $('.cadastrarE').val('Atualizar');


            // recuperar os dados na linha com as classes correspondentes
            var id = linha.find('.id').text();
            var nome = linha.find('.nome').text();
            var descricao = linha.find('.descricao').text();
            var instrutor = linha.find('[data-idInstrutor]').attr('data-idInstrutor');
            console.log(instrutor)
            var data = linha.find('.data').text();  
            var duracaoMinutos = linha.find('.duracaoMinutos').text();
            var valorInscricao = linha.find('.valorInscricao').text();


            // dividir a string em dia, mês e ano
            var dataHora = data.split(' ');

            var partesData = dataHora[0].split('/');
            var dia = partesData[0];
            var mes = partesData[1];
            var ano = partesData[2];

            // concatenar os valores no formato "aaaa-mm-dd"
            var dataFormatada = ano + "-" + mes + "-" + dia + "T" + dataHora[1];


            // preencher os campos do formulário com esses dados
            $('#tipo').val(id);
            $('#nome').val(nome);
            $('#desc').val(descricao);
            $('#<%= inst.ClientID %>').val('1');
            $('#data').val(dataFormatada);
            $('#duracao').val(duracaoMinutos);
            $('#valor').val(valorInscricao);


        });

        $('#modalLives').on('hidden.bs.modal', function () {
            // redefinir todos os campos do formulário para seus valores padrão
            $('#tipo').val(0);
            $('#formLives')[0].reset();
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
                            data: { 'acao': 'deletarLive', 'id' : id },
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
