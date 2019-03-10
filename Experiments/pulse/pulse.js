function loaderShow(){
$("#elem").show('slow');
setTimeout(function() { $("#elem").hide('slow'); }, 2000);
}

function showHide(element_id) {
                //Если элемент с id-шником element_id существует
                if (document.getElementById(element_id)) { 
                    //Записываем ссылку на элемент в переменную obj
                    var obj = document.getElementById(element_id); 

                    if (obj.style.display != "block") { 
			obj.style.display = "block";
			setTimeout(function() { obj.style.display = "none"; }, 2000);
                        
                    }
                    
/* вариант по нажатию показывать и скрывать по отдельному
//Если css-свойство display не block, то: 
                    if (obj.style.display != "block") { 
setTimeout(function() { $("#elem").hide('slow'); }, 2000);
                        obj.style.display = "block"; //Показываем элемент
                    }
                    else obj.style.display = "none"; //Скрываем элемент
*/
                }
                //Если элемент с id-шником element_id не найден, то выводим сообщение
                else alert("Элемент с id: " + element_id + " не найден!"); 
            }   

function OnClick(){
console.log("Вы перестали печатать.");
}
