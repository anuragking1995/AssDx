

Create table Actor(
	ActorID char(5) constraint pk_Actor_ActorID primary key,
	ActorName varchar(100),
	Sex char(1) constraint ch_Actor_Sex check  (Sex in ('M','F')),
	DOB date,
	Bio text
)

Create table Producer(
	ProducerID char(5) constraint pk_Producer_ProducerID primary key,
	ProducerName varchar(100),
	Sex char(1), constraint chk_Actor_Sex check  (Sex in ('M','F')),
	DOB date,
	Bio text
)


Create table Movie(
	MovieId char(5) constraint pk_Movie_MovieID primary key,
	MovieName varchar(100),
	YearOfRelease smallint,
	Plot text,
	Poster varbinary(max),
	ProducerID char(5) constraint fk_Movie_producerID references Producer(ProducerID)
)

Create table ActorMovie(
	ActorID char(5) constraint fk_ActorMovie_ActorID references Actor(ActorID),
	MovieID char(5) constraint fk_ActorMovie_MovieID references Movie(MovieID),
	Constraint pk_ActorMovie primary key(ActorID,MovieID)
)



