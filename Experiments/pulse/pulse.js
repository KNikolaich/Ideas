function loaderShow(){
$("#elem").show('slow');
setTimeout(function() { $("#elem").hide('slow'); }, 2000);
}

function showHide(element_id) {
                //���� ������� � id-������ element_id ����������
                if (document.getElementById(element_id)) { 
                    //���������� ������ �� ������� � ���������� obj
                    var obj = document.getElementById(element_id); 

                    if (obj.style.display != "block") { 
			obj.style.display = "block";
			setTimeout(function() { obj.style.display = "none"; }, 2000);
                        
                    }
                    
/* ������� �� ������� ���������� � �������� �� ����������
//���� css-�������� display �� block, ��: 
                    if (obj.style.display != "block") { 
setTimeout(function() { $("#elem").hide('slow'); }, 2000);
                        obj.style.display = "block"; //���������� �������
                    }
                    else obj.style.display = "none"; //�������� �������
*/
                }
                //���� ������� � id-������ element_id �� ������, �� ������� ���������
                else alert("������� � id: " + element_id + " �� ������!"); 
            }   

function OnClick(){
console.log("�� ��������� ��������.");
}
