<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="Inscricoes.aspx.vb" Inherits="Inscricoes" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    
    <script type="text/javascript">
        function mostrarMensagem() {
            Swal.fire(
                'Sucesso!',
                'Inscricoes cadastrado com sucesso!',
                'success'
            )
        }
        var parametro = '<%= HttpContext.Current.Session("statusAdd") %>';
             <% Session.Remove("statusAdd") %>

        var parametro2 = '<%= HttpContext.Current.Session("statusUpdate") %>';
             <% Session.Remove("statusUpdate") %>

        if (parametro) {
            Swal.fire("Sucesso", "Inscrição cadastrada com sucesso!", "success");
        }
        if (parametro2) {
            Swal.fire("Sucesso", "Inscrição editada com sucesso!", "success");
        }
    </script>

    <section class="inscricoes">
<div class="modal fade" id="modalInscricoes" tabindex="-1" aria-labelledby="exampleModalLabel" aria-hidden="true">
    <div class="modal-dialog">
    <div class="modal-content">
        <div class="modal-header">
        <h1 class="modal-title fs-5" id="exampleModalLabel"><span class="cadastrarE">Cadastrar</span> Inscrição</h1>
        <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
        </div>
        <div class="modal-body">
            <form id="formInscricoes" runat="server">
                <input type="hidden" name="tipo" value="0" id="tipo" />
                <input type="hidden" name="statusPagamento" value="0" id="statusPagamento" />
                <div class="row">
                    <div class="col-md-6 mb-3">
                        <label for="liveId" class="form-label">Live <button type="button" class="btnInfo" data-toggle="tooltip" data-placement="top" title="Somente lives que não aconteceram ainda vão ser listadas"><i class="fas fa-info-circle" data-toggle="tooltip" data-placement="top"></i></button></label>
                        <select class="form-control" name="liveId" required id="liveId"  runat="server" >
                            <option value="">Selecione uma live</option>
                        </select>
                    </div>
                    <div class="col-md-6 mb-3">
                        <label for="inscritoId" class="form-label">Aluno</label>
                        <select class="form-control" name="inscritoId" required id="inscritoId" runat="server" >
                            <option value="">Selecione um aluno</option>
                        </select>
                    </div>
                    <div class="col-md-6 mb-3">
                        <label for="valor" class="form-label">Valor</label>
                        <input type="text" class="form-control" name="valor" required id="valor"
                            placeholder="Valor" />
                    </div>
                    <div class="col-md-6 mb-3">
                        <label for="dataVencimento" class="form-label">Data de vencimento</label>
                        <input type="date" class="form-control" name="dataVencimento" required id="dataVencimento"
                            placeholder="Data de vencimento" />
                    </div>
                </div>


                <button type="button" class="btn btn-secondary" data-bs-dismiss="modal">Fechar</button>
                <button type="button" class="btn btn-secondary" >Linha digitável</button>
                <asp:Button runat="server" ID="btnAction" Class="btn btn-primary cadastrarE" Text="Cadastrar"/>

                <div>
                    <p> 00000.00000 00000.000000 00000.000000 0 00000000000</p>
                </div>
            </form>
        </div>
    </div>
    </div>
</div>
        <div class="container">
            <div class="glass">
                <div class="top_info">
                    <h2 class="page_title">Inscrições</h2>
                    <a data-bs-toggle="modal" data-bs-target="#modalInscricoes"><i class="fa-regular fa-plus"></i></a>
                </div>                
                
                <table id="Inscricoes" class="table table-striped w-100">
                    <thead>
                        <tr>
                            <th>ID</th>
                            <th>Live</th>
                            <th>Aluno</th>
                            <th>Valor</th>
                            <th>DataVencimento</th>
                            <th>Status</th>
                            <th>Ações</th>
                        </tr>
                    </thead>
                    <tbody id="tabela_inscricoes" runat="server">
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
                            <th>Live</th>
                            <th>Aluno</th>
                            <th>Valor</th>
                            <th>DataVencimento</th>
                            <th>Status</th>
                            <th>Ações</th>
                        </tr>
                    </tfoot>
                </table>
            </div>
        </div>
    </section>
    <script>
        $(document).ready(function () {
            $('#Inscricoes').DataTable({
                "language": {
                    "url": "https://cdn.datatables.net/plug-ins/1.10.25/i18n/Portuguese-Brasil.json"
                },

            });
        });

        $('.editar').click(function () {
            // obter a linha da tabela onde o botão foi clicado
            var linha = $(this).closest('tr');
            $('#modalInscricoes').modal('show');

            $('.cadastrarE').text('Atualizar');
            $('.cadastrarE').val('Atualizar');


            // recuperar os dados na linha com as classes correspondentes
            var id = linha.find('.id').text();
            var liveID = linha.find('[data-liveID]').attr('data-liveID');
            var inscritoID = linha.find('[data-inscritoID]').attr('data-inscritoID');
            var valor = linha.find('.valor').text();
            var statusPagamento = linha.find('.statusPagamento').text();
            
            // obter a data no formato "dd/mm/aaaa"
            var data = linha.find('.dataVencimento').text();

            // dividir a string em dia, mês e ano
            var partesData = data.split('/');
            var dia = partesData[0];
            var mes = partesData[1];
            var ano = partesData[2];

            // concatenar os valores no formato "aaaa-mm-dd"
            var dataVencimento = ano + "-" + mes + "-" + dia;

            if ($('#<%= liveID.ClientID %> option[value="' + liveID + '"]').hasClass('Realizada'))
            {
                $('#<%= liveID.ClientID %> option[value="' + liveID + '"]').removeAttr('hidden');
            }



            // preencher os campos do formulário com esses dados
            $('#tipo').val(id);
            $('#<%= liveID.ClientID %>').val(liveID);

            $('#<%= inscritoID.ClientID %>').val(inscritoID);
            $('#valor').val(valor);
            $('#dataVencimento').val(dataVencimento);
            $('#statusPagamento').val(statusPagamento);

            // statusPagamento
        });

        $('#modalInscricoes').on('hidden.bs.modal', function () {
            // redefinir todos os campos do formulário para seus valores padrão
            $('#tipo').val(0);
            $('#statusPagamento').val(0);
            $('#formInscricoes')[0].reset();

            $('.cadastrarE').text('Cadastrar');
            $('.cadastrarE').val('Cadastrar');

            $("#<%= liveID.ClientID %> option").each(function () {
                if ($(this).hasClass("Realizada") & $(this).attr("hidden") == undefined) {
                    $(this).attr("hidden", true);
                }
            });

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
                        data: { 'acao': 'deletarInscricoes', 'id': id },
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

        function dataVencimento(dataVencimento) {
            var dataBase = new Date(1997, 9, 7);
            var dataVenc = new Date(
                parseInt(dataVencimento.substr(6, 4)),
                parseInt(dataVencimento.substr(3, 2)) - 1,
                parseInt(dataVencimento.substr(0, 2))
            );
            var digitos = (dataVenc - dataBase) / 86400000;  // 86400000 milesegunsdo de um dia
            return digitos.toString().padStart(4, "0");
        }

        function formatarValor(valor) {
            return valor.replace(",", "").padStart(10, "0");
        }

        function gerarLinhaDigitavel(dataVencimento, valor) {
            var Vencimento = dataVencimento(dataVencimento);
            var valorF = formatarValor(valor);
            var linhaDigitavel = "00000.00000 00000.000000 00000.000000 0 " + Vencimento + valorF;
            return linhaDigitavel;
        }
    </script>
</asp:Content>

