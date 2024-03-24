function Act(evt)  {
    var checkList = document.getElementById('list1');
    if (checkList.classList.contains('visible'))
      checkList.classList.remove('visible');
    else
      checkList.classList.add('visible');
  }