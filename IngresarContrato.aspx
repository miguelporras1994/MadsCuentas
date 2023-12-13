<%@ Page Language="C#" AutoEventWireup="true" CodeFile="IngresarContrato.aspx.cs" Inherits="IngresarContrato" MasterPageFile="~/MasterPage.master" %>



<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

     <meta name="viewport" content="width=device-width, initial-scale=1">

    <!--[if lt IE 11]>
        <script src="//cdnjs.cloudflare.com/ajax/libs/json3/3.3.2/json3.min.js"></script>
    <![endif]-->

   
     <!-- HTML5 shim, for IE6-8 support of HTML5 elements -->
    <!--[if lt IE 11]>
      <script src="http://html5shim.googlecode.com/svn/trunk/html5.js"></script>
    <![endif]-->
<link rel="stylesheet" href="estilo.css">
<link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.6/css/bootstrap.min.css">
  <script src="https://ajax.googleapis.com/ajax/libs/jquery/1.12.0/jquery.min.js"></script>
  <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.6/js/bootstrap.min.js"></script>
   
    
      <link rel="stylesheet" href="css/thickbox.css" type="text/css" media="screen" />

    <script type="text/javascript" language="javascript" src="js/DataTables-1.7.6/media/js/jquery.dataTables.js"></script>
		<script type="text/javascript" charset="utf-8">
		    $(document).ready(function () {
		        $('#example').dataTable();
		    });
		</script>

    <script type="text/javascript" language="javascript" src="js/json2.js"></script>
    
    <script language="javascript" type="text/javascript" src="js/thickbox.js"></script> 
    
    <script type="text/javascript" language="javascript" src="js/jquery.mask.js"></script>

    <script type="text/javascript">
        $(document).ready(function () {
            $('.date').mask('00/00/0000');
            $('.time').mask('00:00:00');
            $('.date_time').mask('00/00/0000 00:00:00');
            $('.cep').mask('00000-000');
            $('.phone').mask('0000-0000');
            $('.phone_with_ddd').mask('(00) 0000-0000');
            $('.phone_us').mask('(000) 000-0000');
            $('.mixed').mask('AAA 000-S0S');
            $('.ip_address').mask('099.099.099.099');
            $('.percent').mask('##0,00%', { reverse: true });
            $('.clear-if-not-match').mask("00/00/0000", { clearIfNotMatch: true });
            $('.placeholder').mask("00/00/0000", { placeholder: "__/__/____" });
            $('.fallback').mask("00r00r0000", {
                translation: {
                    'r': {
                        pattern: /[\/]/,
                        fallback: '/'
                    },
                    placeholder: "__/__/____"
                }
            });

            $('.selectonfocus').mask("00/00/0000", { selectOnFocus: true });

            $('.cep_with_callback').mask('00000-000', {
                onComplete: function (cep) {
                    console.log('Mask is done!:', cep);
                },
                onKeyPress: function (cep, event, currentField, options) {
                    console.log('An key was pressed!:', cep, ' event: ', event, 'currentField: ', currentField.attr('class'), ' options: ', options);
                },
                onInvalid: function (val, e, field, invalid, options) {
                    var error = invalid[0];
                    console.log("Digit: ", error.v, " is invalid for the position: ", error.p, ". We expect something like: ", error.e);
                }
            });

            $('.crazy_cep').mask('00000-000', {
                onKeyPress: function (cep, e, field, options) {
                    var masks = ['00000-000', '0-00-00-00'];
                    mask = (cep.length > 7) ? masks[1] : masks[0];
                    $('.crazy_cep').mask(mask, options);
                }
            });

            $('.cpf').mask('000.000.000-00', { reverse: true });
            $('.money').mask('000.000.000.000.000,00', { reverse: true });

            var SPMaskBehavior = function (val) {
                return val.replace(/\D/g, '').length === 11 ? '(00) 00000-0000' : '(00) 0000-00009';
            },
            spOptions = {
                onKeyPress: function (val, e, field, options) {
                    field.mask(SPMaskBehavior.apply({}, arguments), options);
                }
            };

            $('.sp_celphones').mask(SPMaskBehavior, spOptions);

            $(".bt-mask-it").click(function () {
                $(".mask-on-div").mask("000.000.000-00");
                $(".mask-on-div").fadeOut(500).fadeIn(500)
            })


        });
</script>
  
    <div>
    
    </div>
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>


    <ajaxToolkit:TabContainer ID="TabContainer1" runat="server">

        <ajaxToolkit:TabPanel HeaderText="Datos Contratista">
              
             <ContentTemplate>
                
            
        </ContentTemplate>


            
        </ajaxToolkit:TabPanel>

         <ajaxToolkit:TabPanel HeaderText="Datos Contratista">
              
             <ContentTemplate>
                
            
        </ContentTemplate>


            
        </ajaxToolkit:TabPanel>

    </ajaxToolkit:TabContainer>



    <div class="form-horizontal">

       
         <div class="row">
            <div class="col-md-4">

                <div class="form-group">
                    <label class="control-label" for="anio">Año contrato</label>

                   <asp:DropDownList runat="server"  class="form-control text-box single-line" ID="anio" name="anio">

                     </asp:DropDownList>
                    <span class="field-validation-valid text-danger" data-valmsg-for="anio" data-valmsg-replace="true"></span>

                </div>

            </div>


            <div class="col-md-4">
                <div class="form-group">
                    <label class="control-label" for="anio">Número contrato</label>
                    <asp:TextBox  runat="server"  class="form-control text-box single-line" ID="numero_contrato" name="numero_contrato" type="text" value=""></asp:TextBox>
                    <span class="field-validation-valid text-danger" data-valmsg-for="anio" data-valmsg-replace="true"></span>
                </div>
            </div>

            <div class="col-md-4">
                <div class="form-group">
                    <label class="control-label" for="abogado">Abogado responsable</label>
                    <!--<input class="form-control text-box single-line" ID="abogado" name="abogado" type="text" value="">-->
                   <asp:DropDownList runat="server"  class="form-control text-box single-line" ID="abogado" name="abogado"  ></asp:DropDownList>
                    <span class="field-validation-valid text-danger" data-valmsg-for="anio" data-valmsg-replace="true"></span>
                </div>
            </div>

            <div class="col-md-4">
                <div class="form-group">
                    <label class="control-label" for="sireci">SIRECI 2014</label>
                    <!-- <input class="form-control text-box single-line" ID="sireci" name="sireci" type="text" value=""> -->
                   <asp:DropDownList runat="server"  class="form-control" ID="sireci" name="sireci" >
                       
                     </asp:DropDownList>
                    <span class="field-validation-valid text-danger" data-valmsg-for="anio" data-valmsg-replace="true"></span>
                </div>
            </div>

           



        </div>

    </div>

     <hr />

        <h5>TIPO DE CONTRATO Y/O CONVENIO</h5>




        <div class="row">

            <div class="col-md-4">
                <div class="form-group">
                    <label class="control-label">Modalidad de selección</label>
                    <asp:DropDownList runat="server"  class="form-control" ID="modalidad_seleccion" name="modalidad_seleccion">
                            
                     </asp:DropDownList>
                </div>
            </div>


            <div class="col-md-4">
                <div class="form-group">
                    <label class="control-label">Tipo de contrato</label>
                    <asp:DropDownList runat="server"  class="form-control" ID="tipo_contrato" name="tipo_contrato">
                     </asp:DropDownList>
                </div>
            </div>
            



            <div class="col-md-4">
                <div class="form-group">
                    <label class="control-label" for="anio">Causales dentro de la modalidad de selección</label>
                    <asp:DropDownList runat="server"  class="form-control text-box single-line" ID="causales_modalidad" name="causales_modalidad">
                           
                     </asp:DropDownList>
                </div>
            </div>


        </div>


        <div class="row">
            <div class="col-md-4">
                <div class="form-group">
                    <label class="control-label" for="anio">Clase de contrato</label>
                    <asp:DropDownList runat="server"  class="form-control text-box single-line" ID="clase_contrato" name="clase_contrato">
                            
                     </asp:DropDownList>
                </div>
            </div>



            <div class="col-md-4">
                <div class="form-group">
                    <label class="control-label" for="anio">Número de proceso de selección</label>
                    <asp:TextBox  runat="server"  class="form-control text-box single-line" ID="numero_proceso" name="numero_proceso" type="text" value="" />
                    <span class="field-validation-valid text-danger" data-valmsg-for="anio" data-valmsg-replace="true"></span>
                </div>
            </div>

        </div>

        <hr />
        <h4> Datos contratista </h4>


        <div class="row">

            <div class="col-md-4">
                <div class="form-group">
                    <label class="control-label" for="anio">Profesionales / Apoyo a la gestión</label>
                    <asp:DropDownList runat="server"  class="form-control text-box single-line" ID="tipo_apoyo" name="tipo_apoyo">
                       
                     </asp:DropDownList>
                    <span class="field-validation-valid text-danger" data-valmsg-for="anio" data-valmsg-replace="true"></span>
                </div>
            </div>


            <div class="col-md-4">
                <div class="form-group">
                    <label class="control-label" for="anio">Nombre contratista</label>
                    <asp:TextBox  runat="server"  class="form-control text-box single-line" ID="nombre_contratista" name="nombre_contratista" type="text" value="" />
                    <span class="field-validation-valid text-danger" data-valmsg-for="anio" data-valmsg-replace="true"></span>
                </div>
            </div>



            <div class="col-md-4">
                <div class="form-group">
                    <label class="control-label" for="tipo_naturaleza">Tipo de naturaleza</label>

                    <asp:DropDownList runat="server"  class="form-control text-box single-line" ID="tipo_naturaleza" name="tipo_naturaleza">
                       
                     </asp:DropDownList>
                    <span class="field-validation-valid text-danger" data-valmsg-for="anio" data-valmsg-replace="true"></span>
                </div>
            </div>


       </div>




        <div class="row">


            <div class="col-md-4">

                <div class="form-group">
                    <label class="control-label" for="anio">Tipo de documento</label>
                    <asp:DropDownList runat="server"  class="form-control text-box single-line" ID="tipo_documento" name="tipo_documento">

                       

                     </asp:DropDownList>
                    <span class="field-validation-valid text-danger" data-valmsg-for="anio" data-valmsg-replace="true"></span>
                </div>
            </div>
           
           


            <div class="col-md-4">

                <div class="form-group">
                    <label class="control-label" for="anio">Número documento (Sin digito de verificación  ni caracteres ) </label>

                    <asp:TextBox  runat="server"  class="form-control text-box single-line" ID="numero_documento" name="numero_documento" type="text" value="" />
                    <span class="field-validation-valid text-danger" data-valmsg-for="anio" data-valmsg-replace="true"></span>
                </div>

            </div>

           
            <div class="col-md-4">
                <div class="form-group">
                    <label class="control-label" for="anio">Digito de verificación</label>
                    <asp:DropDownList runat="server"  class="form-control text-box single-line" ID="digito_verificacion" name="digito_verificacion">
                                

                     </asp:DropDownList>
                </div>
            </div>


        </div>

        <div class="row">
          
            <div class="col-md-4">
                <div class="form-group">
                    <label class="control-label" for="anio">Perfil profesional para 2017 </label>
                    <asp:TextBox  runat="server"  class="form-control text-box single-line" ID="perfil_profesional" name="perfil_profesional" type="text" value="" />
                    <span class="field-validation-valid text-danger" data-valmsg-for="anio" data-valmsg-replace="true"></span>
                </div>
            </div>



            <div class="col-md-4">

                <div class="form-group">
                    <label class="control-label" for="anio">Nombre representante legal </label>
                    <asp:TextBox  runat="server"  class="form-control text-box single-line" ID="nombre_representante_legal" name="nombre_representante_legal" type="text" value="N/A" />
                    <span class="field-validation-valid text-danger" data-valmsg-for="anio" data-valmsg-replace="true"></span>
                </div>
            </div>

            <div class="col-md-4">
                <div class="form-group">
                    <label class="control-label" for="anio">Tipo de identificación representante legal del contratista</label>
                    <asp:DropDownList runat="server"  class="form-control text-box single-line" ID="DropDownList2" name="tipo_documento">
                       

                     </asp:DropDownList>
                    <span class="field-validation-valid text-danger" data-valmsg-for="anio" data-valmsg-replace="true"></span>
                </div>
            </div>
        </div>


        <div class="row">

            <div class="col-md-4">
                <div class="form-group">
                    <label class="control-label" for="anio">Número de identificación del representante Legal</label>
                    <asp:TextBox  runat="server"  class="form-control text-box single-line" ID="numero_identificacion_contratista_rp" name="numero_identificacion_contratista_rp"  type="text" value="N/A" />
                    <span class="field-validation-valid text-danger" data-valmsg-for="anio" data-valmsg-replace="true"></span>
                </div>
            </div>

            
            <div class="col-md-4">
                <div class="form-group">
                    <label class="control-label" for="anio">Tiene RUP</label>
                    <asp:DropDownList runat="server"  class="form-control" ID="clasificacion_rup" name="clasificacion_rup"  >
                       
                     </asp:DropDownList>
                </div>
            </div>
        </div>

        <hr />
        <h4> INFORMACIÓN CONTRATO </h4>

        <div class="row">

            <div class="col-md-4">
                <div class="form-group">
                    <label class="control-label" for="anio">Dependencia solicitante de la contratación</label>
                    <asp:DropDownList runat="server"  class="form-control" ID="dependencia_contratante" name="dependencia_contratante">


                     </asp:DropDownList>
                    
                </div>

            </div>


            <div class="col-md-4">
                <label class="control-label" for="anio">Grupo Dependencia solicitante de la contratación</label>
                <asp:DropDownList runat="server"  class="form-control" ID="grupo_contratante" name="grupo_contratante"></asp:DropDownList>
            </div>

        </div>
    
        <div class="row">

            <div class="col-md-6">
                <div class="form-group">
                    <label for="comment">Objeto:</label>
                    <textarea class="form-control" style="min-width: 85%; resize:none" rows="5" ID="objeto"></textarea>
                </div>
            </div>

            <div class="col-md-6">
                <div class="form-group">
                    <label for="comment">Obligaciones:</label>
                    <textarea class="form-control" style="min-width: 85%; resize:none" rows="5" ID="obligaciones"></textarea>
                </div>
            </div>
        </div>



        <div class="row">

            <div class="col-md-4">
                <div class="form-group">
                    <label class="control-label" for="anio">Valor del contrato en letras</label>
                    <asp:TextBox  runat="server"  type="text" class="form-control text-box single-line" ID="valor_contrato_letras" name="valor_contrato_letras" />
                    <span class="field-validation-valid text-danger" data-valmsg-for="anio" data-valmsg-replace="true"></span>
                </div>
            </div>

            <div class="col-md-4">
                <div class="form-group">
                    <label class="control-label" for="anio">Valor del contrato</label>
                    <asp:TextBox  runat="server"  type="text" class="form-control text-box single-line" ID="valor_contrato" name="valor_contrato" />
                    <span>Solo en números, sin puntos ni comas</span>
                    <span class="field-validation-valid text-danger" data-valmsg-for="anio" data-valmsg-replace="true"></span>
                </div>
            </div>

        </div>


        <div class="row">
            <div class="col-md-4">
                <div class="form-group">
                    <label class="control-label" for="anio">Tipos de recursos</label>
                    <asp:DropDownList runat="server"  class="form-control" ID="tipo_recursos_contrato" name="tipo_recursos_contrato">
                       
                     </asp:DropDownList>
                </div>
            </div>


            <div class="col-md-4">
                <div class="form-group">
                    <label class="control-label" for="anio">Valor recursos del ministerio</label>
                    <asp:TextBox  runat="server"  type="text"  value="0" class="form-control text-box single-line" ID="valor_recursos_mads" name="valor_recursos_mads" required="" />
                    <span class="field-validation-valid text-danger" data-valmsg-for="anio" data-valmsg-replace="true"></span>
                </div>
            </div>

            <div class="col-md-4">
                <div class="form-group">
                    <label class="control-label" for="anio">Valor recursos fonam</label>
                    <asp:TextBox  runat="server"  type="text" value="0" disabled="" class="form-control text-box single-line" ID="valor_recursos_fonam" name="valor_recursos_fonam" />
                    <span class="field-validation-valid text-danger" data-valmsg-for="anio" data-valmsg-replace="true"></span>
                </div>
            </div>

            <div class="col-md-4">
                <div class="form-group">
                    <label class="control-label" for="anio"> Valor pago mensual</label>
                    <asp:TextBox  runat="server"  type="text" class="form-control text-box single-line" ID="valor_pago_mensual" name="valor_pago_mensual" />
                    <span class="field-validation-valid text-danger" data-valmsg-for="anio" data-valmsg-replace="true"></span>
                </div>
            </div>
        </div>



        <div class="row">

            <div class="col-md-4">
                <div class="form-group">
                    <label class="control-label">Contrato con recursos de otra entidad</label>
                    <asp:DropDownList runat="server"  class="form-control" ID="recursos_otra_entidad" name="recursos_otra_entidad">
                       
                     </asp:DropDownList>
                </div>
            </div>



            <div class="col-md-4">
                <div class="form-group">
                    <label class="control-label" for="anio">Tipo de recursos de otra entidad</label>
                    <asp:DropDownList runat="server"  class="form-control text-box single-line" ID="tipo_recursos_otra_entidad" name="tipo_recursos_otra_entidad">
                        
                     </asp:DropDownList>
                </div>
            </div>


            <div class="col-md-4">
                <div class="form-group">
                    <label class="control-label" for="valor_recursos_otra_entidad">Valor recursos de otra entidad (En número) </label>
                    <asp:TextBox  runat="server"  type="text" value="0" class="form-control text-box single-line" ID="valor_recursos_otra_entidad" name="valor_recursos_otra_entidad" />
                    <span class="field-validation-valid text-danger" data-valmsg-for="anio" data-valmsg-replace="true"></span>
                </div>
            </div>

        </div>



        <div class="row">

            <div class="col-md-4">
                <div class="form-group">
                    <label class="control-label" for="anio">Entidad de donde provienen los recursos</label>
                    <asp:TextBox  runat="server"  type="text" class="form-control text-box single-line" ID="nombre_otra_entidad" name="nombre_otra_entidad" />
                    <span class="field-validation-valid text-danger" data-valmsg-for="anio" data-valmsg-replace="true"></span>
                </div>
            </div>

            <div class="col-md-4">
                <div class="form-group">
                    <label class="control-label" for="anio">Entidad de donde provienen los recursos (NIT) </label>
                    <asp:TextBox  runat="server"  type="text" class="form-control text-box single-line" ID="nit_otra_entidad" name="nombre_otra_entidad" />
                    <span class="field-validation-valid text-danger" data-valmsg-for="anio" data-valmsg-replace="true"></span>
                </div>
            </div>
        </div>
      
      
       <hr>
       
       <h4> INGRESE LA INFORMACIÓN DE RIESGOS DE  GARANTÍAS <small> ( Debe ingresar al menos un registro) </small> </h4>

        <div class="row">
                
            
            <div class="col-md-4">
                <div class="form-group">
                    <label class="control-label" for="anio">Garantías</label>
                    <asp:DropDownList runat="server"  class="form-control text-box single-line" ID="tiene_garantias" name="tiene_garantias">
                        
                     </asp:DropDownList>
                   
                </div>
            </div>
            

            <div class="col-md-4">
                <div class="form-group">
                    <label class="control-label" for="anio">Clase Garantías</label>
                    <asp:DropDownList runat="server"  class="form-control text-box single-line" ID="clase_garantias" name="clase_garantias">
                        
                     </asp:DropDownList>

                </div>
            </div>


            <div class="col-md-4">
                <div class="form-group">
                    <label class="control-label" for="anio">Número de póliza</label>
                    <asp:TextBox  runat="server"  class="form-control text-box single-line" ID="numero_poliza" name="numero_poliza" type="text" />

                </div>
            </div>

            <div class="col-md-4">
                <div class="form-group">
                    <label class="control-label" for="anio">Entidad aseguradora</label>
                    <asp:TextBox  runat="server"  class="form-control text-box single-line" ID="entidad_aseguradora" name="entidad_aseguradora" type="text" />
                       
                </div>
            </div>
            
            
            <div class="col-md-4">
                <div class="form-group">
                    <label class="control-label" for="anio">Fecha de expedición de Garantía</label>
                    <asp:TextBox  runat="server"  class="form-control text-box single-line" ID="fecha_expedicion_garantia"  Readonly="true" name="fecha_expedicion_garantia" type="text" />
                </div>
            </div>
            
            
            <div class="col-md-4">
                <div class="form-group">
                    <label class="control-label" for="anio">Fecha de aprobación de Garantía</label>
                    <asp:TextBox  runat="server"  class="form-control text-box single-line" ID="fecha_aprobacion_garantia"   ReadOnly="true"  name="fecha_aprobacion_garantia" type="text" />
                </div>
            </div>    
                     

        </div>
        <div class="row">
            <div class="col-md-4">
                <button class="btn btn-info" id="btn_adicionar_riesgo">Adicionar RIESGO</button>
            </div>
        </div>

        <table class="table table-bordered" id="tabla_garantias">
            <thead>
              <tr>
                 <td>
                    Riesgo asegurado
                </td>
                <td>
                    % Asegurado
                </td>
                <td>
                    Valor asegurado
                </td>
                <td>
                    Vigencia Desde
                </td>
                <td>
                    Vigencia Hasta
                </td>

                <td>
                    Eliminar
                </td>

               </tr>
            </thead>
            <tbody>

            </tbody>
        </table>

        <br /><br />



            <hr />
            <h4> INGRESE LA INFORMACIÓN DE CDP <small> ( Debe ingresar al menos un registro) </small> </h4>
           
            
        plazo_ejecucion_final_dias
            <table class="table table-bordered" id="tabla_cdp">
                <thead>
                    <tr>
                        <td>
                            Número del CDP
                        </td>

                        <td>
                            Valor del RP
                        </td>
                        <td>
                            Dependencia
                        </td>
                        <td>
                            FECHA CDP (INICIAL)
                        </td>
                        <td>
                            Número del RP:
                        </td>
                        <td>
                            FECHA RP (INICIAL)
                        </td>

                        <td>
                            AFECTACIÓN DEL RECURSO
                        </td>

                        <td>
                            FUENTE DE FINANCIACIÓN
                        </td>

                        <td>
                            Eliminar
                        </td>
                    </tr>
                </thead>
                <tbody></tbody>
            </table>

            <div class="row">
                <div class="col-md-4">
                    <asp:Button runat="server" class="btn btn-primary" ID="btn_adicionar_cdp" Text="Adicionar CDP"></asp:Button>
                </div>
            </div>

            <hr />

            <h4> UBICACIÓN DE EJECUCIÓN </h4>

            <div class="row">


                <div class="col-md-4">
                    <div class="form-group">
                        <label class="control-label" for="anio">Anticipo</label>
                        <asp:DropDownList runat="server"  class="form-control" ID="anticipo" name="anticipo">
                            
                         </asp:DropDownList>
                    </div>
                </div>



                <div class="col-md-4">
                    <div class="form-group">
                        <label class="control-label" for="anio">% de anticipo</label>
                        <asp:TextBox  runat="server"  type="text" class="form-control" ID="porcentaje_anticipo" name="porcentaje_anticipo" value="0" />
                        <span class="field-validation-valid text-danger" data-valmsg-for="anio" data-valmsg-replace="true"></span>
                    </div>
                </div>



                <div class="col-md-4">
                    <div class="form-group">
                        <label class="control-label" for="anio"> Valor anticipo (En números)</label>
                        <asp:TextBox  runat="server"  type="text" class="form-control" ID="valor_anticipo_numeros" name="valor_anticipo_numeros" value="0" />
                        <span class="field-validation-valid text-danger" data-valmsg-for="anio" data-valmsg-replace="true"></span>
                    </div>
                </div>
            </div>




            <div class="row">
                <div class="col-md-4">
                    <div class="form-group">
                        <label class="control-label" for="anio">Domicilio</label>
                        <asp:TextBox  runat="server"  type="text" class="form-control" ID="domicilio" name="domicilio" required="" />
                        <span class="field-validation-valid text-danger" data-valmsg-for="anio" data-valmsg-replace="true"></span>
                    </div>
                </div>

                <div class="col-md-4">
                    <div class="form-group">
                        <label class="control-label" for="anio">Correo electrónico</label>
                        <asp:TextBox  runat="server"  type="text" class="form-control" ID="correo_electronico" name="correo_electronico" />
                        <span class="field-validation-valid text-danger" data-valmsg-for="anio" data-valmsg-replace="true"></span>
                    </div>
                </div>

            </div>





            <div class="row">
                <div class="col-md-4">
                    <div class="form-group">
                        <label class="control-label" for="anio">Fecha de suscripción</label>
                        <asp:TextBox  runat="server"  type="text" ReadOnly="true" class="form-control text-box single-line" ID="fecha_suscripcion" name="fecha_suscripcion" />
                        <span class="field-validation-valid text-danger" data-valmsg-for="anio" data-valmsg-replace="true"></span>
                    </div>
                </div>
            </div>


            <div class="row">
                <div class="col-md-6">
                    <div class="form-group">
                        <label class="control-label" for="departamento">Departamento ejecución</label>
                        <asp:DropDownList runat="server"  class="form-control" ID="departamento" name="departamento"></asp:DropDownList >
                    </div>
                </div>
                <div class="col-md-6">
                    <div class="form-group">
                        <label class="control-label" for="ciudad">Ciudad ejecución</label>
                        <asp:DropDownList runat="server"  class="form-control" ID="ciudad" name="ciudad"></asp:DropDownList>
                    </div>
                </div>
            </div>


            <div class="row">
                <div class="col-md-4">
                    <div class="form-group">
                        <label class="control-label" for="anio">Tipo de seguimiento</label>
                        <asp:DropDownList runat="server"  class="form-control" ID="tipo_seguimiento" name="tipo_seguimiento">
                           
                         </asp:DropDownList>
                    </div>
                </div>
            </div>



            <div class="row">



                <div class="col-md-4">
                    <div class="form-group">
                        <label class="control-label" for="anio">Supervisor: nombre completo</label>
                        <asp:TextBox  runat="server"  type="text" class="form-control text-box single-line" ID="nombre_supervisor" name="nombre_supervisor" />
                        <span class="field-validation-valid text-danger" data-valmsg-for="anio" data-valmsg-replace="true"></span>
                    </div>
                </div>

                <div class="col-md-4">
                    <div class="form-group">
                        <label class="control-label" for="anio">Supervisor Tipo de documento</label>
                        <asp:DropDownList runat="server"  class="form-control text-box single-line" ID="supervisor_tipo_documento" name="supervisor_tipo_documento">
                            
                         </asp:DropDownList>
                        <span class="field-validation-valid text-danger" data-valmsg-for="anio" data-valmsg-replace="true"></span>
                    </div>
                </div>


                <div class="col-md-4">
                    <div class="form-group">
                        <label class="control-label" for="anio">Supervisor: número de identificación</label>
                        <asp:TextBox  runat="server"  type="text" class="form-control text-box single-line" ID="documento_supervisor" name="documento_supervisor" />
                        <span class="field-validation-valid text-danger" data-valmsg-for="anio" data-valmsg-replace="true"></span>
                    </div>
                </div>

                <div class="col-md-4">
                    <div class="form-group">
                        <label class="control-label" for="anio">D_V (NIT/RUT)2</label>
                        <asp:TextBox  runat="server"  type="text" class="form-control text-box single-line" ID="dv_documento_supervisor" name="dv_documento_supervisor" />
                        <span class="field-validation-valid text-danger" data-valmsg-for="anio" data-valmsg-replace="true"></span>
                    </div>
                </div>
            </div>


            <div class="row">

                <div class="col-md-4">
                    <div class="form-group">
                        <label class="control-label" for="anio">Supervisor cargo</label>
                        <asp:TextBox  runat="server"  type="text" class="form-control text-box single-line" ID="supervisor_cargo" name="supervisor_cargo" />
                        <span class="field-validation-valid text-danger" data-valmsg-for="anio" data-valmsg-replace="true"></span>
                    </div>
                </div>

                <div class="col-md-4">
                    <div class="form-group">
                        <label class="control-label" for="anio">Dependencia Supervisor</label>
                        <asp:DropDownList runat="server"  class="form-control" ID="dependencia_supervisor" name="dependencia_supervisor">



                         </asp:DropDownList>
                        <span class="field-validation-valid text-danger" data-valmsg-for="anio" data-valmsg-replace="true"></span>
                    </div>
                </div>


            </div>

            <hr />

            <h4>SECOP</h4>


            <div class="row">

                <div class="col-md-4">
                    <div class="form-group">
                        <label class="control-label" for="anio">Código del secop</label>
                        <asp:TextBox  runat="server"  type="text" class="form-control text-box single-line" ID="codigo_secop" name="codigo_secop" />
                        <span class="field-validation-valid text-danger" data-valmsg-for="anio" data-valmsg-replace="true"></span>
                    </div>
                </div>



                <div class="col-md-4">
                    <div class="form-group">
                        <label class="control-label" for="anio">Número de constancia de publicación secop</label>
                        <asp:TextBox  runat="server"  type="text" class="form-control text-box single-line" ID="constancia_publicacion_secop" name="constancia_publicacion_secop" />
                        <span class="field-validation-valid text-danger" data-valmsg-for="anio" data-valmsg-replace="true"></span>
                    </div>
                </div>



                <div class="col-md-4">
                    <div class="form-group">
                        <label class="control-label" for="anio">Fecha de publicación en el secop</label>
                        <asp:TextBox  runat="server"  type="text" ReadOnly="true" class="form-control text-box single-line" ID="fecha_publicacion_secop" name="fecha_publicacion_secop" />
                        <span class="field-validation-valid text-danger" data-valmsg-for="anio" data-valmsg-replace="true"></span>
                    </div>
                </div>
            </div>

            <hr />

            <h4>FECHAS DE EJECUCIÓN INICIAL</h4>
            <div class="row">

                <div class="col-md-4">
                    <div class="form-group">
                        <label class="control-label" for="anio">Fecha de perfeccionamiento y cumplimiento</label>
                        <asp:TextBox  runat="server"  type="text" ReadOnly="true" class="form-control text-box single-line" ID="fecha_cumplimiento_requisitos" name="fecha_cumplimiento_requisitos" />
                        <span class="field-validation-valid text-danger" data-valmsg-for="anio" data-valmsg-replace="true"></span>
                    </div>
                </div>


                <div class="col-md-4">
                    <div class="form-group">
                        <label class="control-label" for="anio">Fecha de inicio </label>
                        <asp:TextBox  runat="server"  class="form-control text-box single-line" ID="fecha_inicio" name="fecha_inicio" ReadOnly="true" />
                        <span class="field-validation-valid text-danger" data-valmsg-for="anio" data-valmsg-replace="true"></span>
                    </div>
                </div>



                <div class="col-md-4">
                    <div class="form-group">
                        <label class="control-label" for="anio">Fecha terminación inicial </label>
                        <asp:TextBox  runat="server"  ReadOnly="true" class="form-control text-box single-line" ID="fecha_terminacion_inicial" name="fecha_terminacion_inicial" />
                        <span class="field-validation-valid text-danger" data-valmsg-for="anio" data-valmsg-replace="true"></span>
                    </div>
                </div>



                <div class="col-md-4">
                    <div class="form-group">
                        <label class="control-label" for="anio">Plazo de ejecución en días(inicial) </label>
                        <asp:TextBox  runat="server"  class="form-control text-box single-line" ID="fecha_ejecucion_dias_inicial" name="fecha_ejecucion_dias_inicial" ReadOnly="true"  />
                        <span class="field-validation-valid text-danger" data-valmsg-for="anio" data-valmsg-replace="true"></span>
                    </div>
                </div>

            </div>


            <div class="row">
                <div class="col-md-4">
                    <div class="form-group">
                        <label class="control-label" for="anio">Plazo de ejecución en meses(inicial) </label> 
                        <asp:TextBox  runat="server"  class="form-control text-box single-line" ID="plazo_ejecucion_meses_inicial" name="plazo_ejecucion_meses_inicial"  ReadOnly="true" />
                        <span class="field-validation-valid text-danger" data-valmsg-for="anio" data-valmsg-replace="true"></span>
                    </div>
                </div>
            </div>


            <div class="row">
                <div class="col-md-6">
                    <div class="form-group">
                        <label class="control-label" for="anio">Plazo de ejecución</label>
                        <asp:TextBox runat="server" TextMode="MultiLine" rows="4" style="min-width: 85%;  resize: none;" class="form-control text-box single-line" ID="plazo_ejecucion_inicial" name="plazo_ejecucion_inicial"></asp:TextBox>
                        <span class="field-validation-valid text-danger" data-valmsg-for="anio" data-valmsg-replace="true"></span>
                    </div>
                </div>
            </div>


            <hr />

            <h4>FECHAS DE EJECUCIÓN FINAL</h4>

            <div class="row">


                <div class="col-md-4">
                    <div class="form-group">
                        <label class="control-label" for="anio">Plazo de ejecución final del contrato (en días) </label>
                        <asp:TextBox  runat="server"  class="form-control text-box single-line" ID="plazo_ejecucion_final_dias" name="plazo_ejecucion_final_dias"  />
                        <span class="field-validation-valid text-danger" data-valmsg-for="anio" data-valmsg-replace="true"></span>
                    </div>
                </div>


                <div class="col-md-4">
                    <div class="form-group">
                        <label class="control-label" for="anio">Plazo de ejecución final del contrato (desde) </label>
                        <asp:TextBox  runat="server"  class="form-control text-box single-line" ID="plazo_ejecucion_final_desde" name="plazo_ejecucion_final_desde" readonly="" />
                        <span class="field-validation-valid text-danger" data-valmsg-for="anio" data-valmsg-replace="true"></span>
                    </div>
                </div>


                <div class="col-md-4">
                    <div class="form-group">
                        <label class="control-label" for="anio">Plazo de ejecución final del contrato (hasta) </label>
                        <asp:TextBox  runat="server"  class="form-control text-box single-line" ID="plazo_ejecucion_final_hasta" name="plazo_ejecucion_final_hasta" readonly="" />
                        <span class="field-validation-valid text-danger" data-valmsg-for="anio" data-valmsg-replace="true"></span>
                    </div>
                </div>

            </div>


            <div class="row">
                <div class="col-md-4">
                    <div class="form-group">
                        <label class="control-label" for="anio"> Porcentaje de avance </label>
                        <asp:TextBox  runat="server"  class="form-control text-box single-line" ID="porcentaje_avance" name="porcentaje_avance" />
                        <span class="field-validation-valid text-danger" data-valmsg-for="anio" data-valmsg-replace="true"></span>
                    </div>
                </div>

                <div class="col-md-4">
                    <div class="form-group">
                        <label class="control-label" for="anio"> Valor total de contrato  </label><br />
                        <span> (antes de liquidación - liberación de saldos)</span>
                        <asp:TextBox  runat="server"  class="form-control text-box single-line" ID="valor_total_antes_liquidacion" name="valor_total_antes_liquidacion" />
                        <span class="field-validation-valid text-danger" data-valmsg-for="anio" data-valmsg-replace="true"></span>
                    </div>
                </div>
            </div>

            <div class="row">
                <div class="col-md-4">
                    <div class="form-group">
                        <label class="control-label" for="estado_contrato"> Estado </label>
                        <asp:DropDownList runat="server"  class="form-control" ID="estado_contrato" name="estado_contrato">
                           
                         </asp:DropDownList>
                    </div>
                </div>
            </div>


            <div class="row">
                <div class="col-md-6">
                    <div class="form-group">
                        <label class="control-label" for="anio">   Observaciones </label>
                        <textarea rows="5" style="min-width: 85%;resize: none;" class="form-control" ID="observaciones" name="observaciones"></textarea>
                        <span class="field-validation-valid text-danger" data-valmsg-for="anio" data-valmsg-replace="true"></span>
                    </div>
                </div>
            </div>


            <div class="row">
                <div class="col-md-4">
                    <div class="form-group">
                        <label class="control-label" for="carpeta"> Carpeta</label>
                        <asp:DropDownList runat="server"  class="form-control text-box single-line" ID="carpeta" name="carpeta" >
                           
                         </asp:DropDownList>
                    </div>
                </div>
            </div>
          


            <div class="row">
                <div class="col-md-4">
                    <div class="form-group">
                        <label class="control-label" for="carpeta"> Entidad</label>
                        <asp:DropDownList runat="server"  class="form-control text-box single-line" ID="entidad_contratante" name="entidad_contratante">
                            
                         </asp:DropDownList>
                    </div>
                </div>
            </div>
            
            
            <div class="row">
                <div class="col-md-4">
                    <div class="form-group">
                        <label class="control-label" for="carpeta">DOC ENTIDAD</label>
                        <asp:TextBox  runat="server"   value="830.115.395-1"  type="text" disabled="" class="form-control text-box single-line" ID="doc_entidad_contratante" name="doc_entidad_contratante"/>
                    </div>
                </div>
            </div>



   
   </asp:Content>
