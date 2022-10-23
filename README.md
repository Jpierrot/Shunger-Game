# Shunger-Game  
###### (본 게시글과 프로젝트의 저작권은 저작자에게 있음을 명시합니다.) 

본 md 파일에서는 이 짤막한 게임을 만들기 위한 과정을 나타내고 있다.

현재 프로젝트 참여 인원은 두명으로  
친구가 기획과 시나리오, 내가 디자인 및 클라이언트 개발을 맡았다.

게임소개 : 10일의 시간동안 자신이 속해있는 당을 선거에서 이기게 만드는 게임

플랫폼 : 모바일 게임으로 제작될 예정

개발 시작일 : 9 / 1

***

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

***

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

***

## 9/6

<b>\<Game View></b>  
<img width="659" alt="image" src="https://user-images.githubusercontent.com/68889645/188650284-e984a532-ec2e-45da-92b6-c014284339cb.png">  

위에 있는 UI 구상도 대로 레이아웃을 다시 짰다.  
앵커를 다시 다 맞춰놔서 나름 여러 비율에서도 정상적으로 작동한다.  
이제 UI를 갈아엎지만 않는다면 손본다고 고생할 일은 없을 듯..

***

## 9/7  

<b>\<Game View></b>  
<img width="654" alt="image" src="https://user-images.githubusercontent.com/68889645/188673278-9da79b62-19d0-4e42-aae2-759a6bb9fd98.png">  
남아있던 UI 레이아웃의 흔적을 가리고 깔끔하게 다듬었다.
이제부턴 코드 작업에 들어가도 될 것 같다.  

UI에 관련한 부분은 MVP 패턴을 활용하여 이벤트 처리를 하는 편이다.  
간단하게 게임 화면(View) <-> UI 매니저(프레젠터) <-> 게임 시스템(모델)의  
관계가 되도록 프로그래밍을 하면 된다.

***

## 9/9 ~ 9/12  

추석이라 쉬는중

***

## 9/13  ~ 9/15  

<b>\<Game View></b>  
<img width="654" alt="image" src="https://user-images.githubusercontent.com/68889645/189850734-2e44f04c-4bad-4d3b-8de2-b8381edb964c.png">

UI에 추가할 부분이 생겨서 새롭게 작업했다.  
(사진들은 위키백과에서 발췌)

그리고 사진을 보면 새로운 폰트가 추가됐는데, 온라인에서 무료로 배포하는 폰트를 다운받아서  
TMP 형식으로 바꿔 사용중이다.

***

## 9/16  

화폐 거래 시스템을 만들었다.  
현재는 구매 기능만 가능하다.

***

## 9/19 ~ 9/22  

<b>\<GameScene></b>  
<img width="464" alt="image" src="https://user-images.githubusercontent.com/68889645/191775405-840d6bff-1447-4bba-be02-fffef3b4f53a.png">    

캐릭터 시스템을 구축 및 구현했다.
엑셀 시트로 캐릭터 데이터를 받아서 가져오고 싶었으나..  
굳이 그럴필요가 없을거 같아 구조체를 만들어 유니티 내부에 데이터를 저장하는 형식으로 바꿨다.  
   
캐릭터 선택 기능 및 프로필 역시 MVP 패턴을 활용해 개발했다.

***

## 9/22 ~ 9/26  

지지율 시스템을 구현했다.  
6개의 지역들이 모두 캐릭터별로 각기 다른 호감도와 지지율을 가지게 만들어  
나름 개연성이 있도록 구현했다.(초기 값은 랜덤)  
  
<b>\<GameView></b>  
<img width="195" alt="image" src="https://user-images.githubusercontent.com/68889645/194024951-223357a6-6da5-46d6-9ddb-f6755bfcf53b.png">  
구현된 지지율이 뷰에서도 제대로 동작하는 모습

***

## 9/27 ~ 9/28  

<b>\<GameView></b>  
<img width="660" alt="image" src="https://user-images.githubusercontent.com/68889645/194261307-c684222c-e24a-451a-9e99-b2b0bb5973fb.png">
조금 바뀐 인 게임 화면 이미지


<b>\<GameView></b>  
<img width="655" alt="image" src="https://user-images.githubusercontent.com/68889645/194261594-79308c36-743b-4edf-9597-4fde5ba7f42b.png">
새롭게 들어간 타이틀 화면    



기존 UI의 구현 방식이 기획에서 제시했던 방향과 맞지 않아
알맞는 쪽으로 새롭게 고쳤다.

제목 및 상단 UI바 같은 경우 일관성 있게 표시 되도록 바꿨고,
픽셀이 늘어지는일도 없도록 수정했다.

***

## 10/3 ~ 10/5

<b>\<View></b>  
<img width="523" alt="image" src="https://user-images.githubusercontent.com/68889645/194026454-83ff8ab0-a6bc-4845-bf68-b54c74bb569f.png">  
<img width="647" alt="image" src="https://user-images.githubusercontent.com/68889645/194263192-8d154319-c2c1-4a3d-b7c8-fc9d40114fb0.png">


지지율을 나타내는 그래프를 구현했다.

지금은 기존에 있던 시스템 코드에서 데이터를 받아오는 방식으로 구현했는데
인터페이스를 활용하면 더 깔끔하게 구현이 가능할 것 같다.
지금은 구현이 먼저니 나중에..

***

## 10/5 ~ 10/8

뉴스 시스템을 만들었다.
뉴스에 들어가는 스크립트들은 유니티 내에 있는 텍스트 파일에서 추출해서 사용한다.
이후 Xml이나 Json으로 바꿔서 데이터를 보관할 예정.
(그냥 플레이어가 쉽게 건드릴 수 있도록 텍스트 파일로 해둘까 고민중이다)

## 10/8 ~ 10/10  

일부 UI를 정의된 데이터에 맞게 생성되도록 바꿨다.  
자동으로 리스트를 생성하고 그에 맞는 오브젝트와 패널 간격을 설정해준다.







