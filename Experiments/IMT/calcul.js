function Person(weight, height, yearOfBirdth){
this.weight = weight;
this.height = height;

var today= new Date();
this.ageYear = today.getYear() +1900 - yearOfBirdth;  // ����������� �� ��������, ��� ��� �� ����� �������� �������� ��� ���������� ���
this.Imt = weight * 10000 /(height*height);
}	

//��������� ��� �� �����/����/��������
function calculat(){
	var weightE = document.getElementById("weight_id");
	weight = weightE.value;
	var heightE = document.getElementById("height_id");
	height = heightE.value;
	
	var yearE = document.getElementById("year_id");
	yearOfBirdth = yearE.value;
	
	
	var person = new Person(weight, height, yearOfBirdth);
	var request = "������� : "+person.ageYear + "\n���: " + person.Imt;
	//alert();
	//console.write(request);
	document.getElementById("request").innerHTML = request;
}
