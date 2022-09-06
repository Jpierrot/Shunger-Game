# Shunger-Game

본 md 파일에서는 이 짤막한 게임을 만들기 위한 과정을 나타내고 있다.

현재 프로젝트 참여 인원은 두명으로  
친구가 기획과 시나리오, 내가 디자인 및 클라이언트 개발을 맡았다.

게임소개 : 10일의 시간동안 자신이 속해있는 당을 선거에서 이기게 만드는 게임

플랫폼 : 모바일 게임으로 제작될 예정

개발 시작일 : 9 / 1

## 9/1 ~ 9/2

### 개발 내용 기획 및 초기 아이디어 기록  
![image](https://user-images.githubusercontent.com/68889645/188362811-14132762-722b-414f-83ff-92ae2ea1d83e.png)

### 유니티로 구현한 레이아웃  
  
    
<b>\<Scene View></b>  
<img width="808" alt="image" src="https://user-images.githubusercontent.com/68889645/188370210-79ff8f6b-b378-49ab-b59e-7d32c4e63444.png">

<b>\<Game View></b>  
<img width="606" alt="image" src="https://user-images.githubusercontent.com/68889645/188370812-221409df-4794-4ac1-b6ed-bf7753530748.png">



<b>Horizontal, Vertical Layout Group</b>(컴포넌트)을 활용해 큰 개념은 가로로 구분하고,  
안에 작은 요소들은 세로로 정리했다. 안드로이드 스튜디오로 따지면 <b>Linear Layout</b>과 유사한 개념  
이렇게 짜두면.. 그래도 어지간한 비율에서 다 호환된다.

(주말은 쉬엄쉬엄)

## 9/5

### UI 1차 수정 및 게임 시스템 초안 확정

초기 기획에서 ui구성이 너무 정적이고, 모바일 기기상의 화면을 너무 많이 가려서 
화면을 대대적으로 수정하기로 했다.  

#### 피드백을 통해 친구가 다시 구상한 ui 구상도  
<img width="464" alt="image" src="https://user-images.githubusercontent.com/68889645/188471553-fa46a2e3-a9e0-4311-a880-f7ba25a335a2.png">

이것도 아직 왼쪽 ui가 거슬린다.
오른쪽은 버튼들을 폴더로 묶어서 접을 수 있게 수정하면 깔끔해지지만  
왼쪽 ui는 플레이어에게 시각적으로 전달해야하기 때문에 쉽게 손대기가 어렵다.  
  

#### 모두가 만족한 UI 구상도 수정안
<img width="1061" alt="image" src="https://user-images.githubusercontent.com/68889645/188478410-f732c219-1e79-4a3a-bf28-4ef5b0edbf52.png">  

그렇게 해서 다시 탄생하게 된 UI.  
휴대폰으로 그려서 살짝 조잡하지만, 화면에서 차지하는 비중이 눈에 띄게 줄어들었고,  
사용자가 더 편리할 수 있도록 여러가지 요소들을 하나로 통합했다.  
스탯 같이 시각적인 요소가 필요한 정보의 경우 사용자가 필요할 때만 볼 수 있도록 수정했다.  
(피그마로 만들었으면 훨씬 편했겠지만.. 기숙사에서 작업중이라 인터넷을 못 썼다)   

## 9/6

<b>\<Game View></b>  
<img width="659" alt="image" src="https://user-images.githubusercontent.com/68889645/188650284-e984a532-ec2e-45da-92b6-c014284339cb.png">



위에 있는 UI 구상도 대로 레이아웃을 다시 짰다.  
앵커를 다시 다 맞춰놔서 나름 여러 비율에서도 정상적으로 작동한다.  
이제 UI를 갈아엎지만 않는다면 손본다고 고생할 일은 없을 듯..

## 9/7  

<b>\<Game View></b>  
<img width="654" alt="image" src="https://user-images.githubusercontent.com/68889645/188673278-9da79b62-19d0-4e42-aae2-759a6bb9fd98.png">  
남아있던 UI 레이아웃의 흔적을 가리고 깔끔하게 다듬었다.
이제부턴 코드 작업에 들어가도 될 것 같다.  

이번 게임에서는 MVP 패턴을 활용하여 이벤트 처리를 하고자 한다.  
설명을 덧대자면, 게임 화면(View) <-> UI 매니저(프레젠터) <-> 게임 시스템(모델)의  
관계가 되도록 프로그래밍을 하려한다.





