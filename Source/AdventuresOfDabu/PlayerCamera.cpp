// Fill out your copyright notice in the Description page of Project Settings.


#include "PlayerCamera.h"
#include "ClickedComponent.h"

// Sets default values
APlayerCamera::APlayerCamera()
{
 	// Set this pawn to call Tick() every frame.  You can turn this off to improve performance if you don't need it.
	PrimaryActorTick.bCanEverTick = true;

}

// Called when the game starts or when spawned
void APlayerCamera::BeginPlay()
{
	Super::BeginPlay();
	
	DabuController = Cast<APlayerController>(GetController());
}

// Called every frame
void APlayerCamera::Tick(float DeltaTime)
{
	Super::Tick(DeltaTime);

}

// Called to bind functionality to input
void APlayerCamera::SetupPlayerInputComponent(UInputComponent* PlayerInputComponent)
{
	Super::SetupPlayerInputComponent(PlayerInputComponent);

	PlayerInputComponent->BindAction(TEXT("Click"), IE_Pressed, this, &APlayerCamera::Click);
}

void APlayerCamera::Click()
{
	UE_LOG(LogTemp, Warning, TEXT("Click"));

	if (DabuController)
	{
		FHitResult HitResult;
		DabuController->GetHitResultUnderCursor(
			ECollisionChannel::ECC_Visibility,
			false,
			HitResult);

		AActor* ClickedActor = HitResult.GetActor(); // 클릭한 액터

		if (ClickedActor)
		{
			UE_LOG(LogTemp, Warning, TEXT("Clicked Actor: %s"), *ClickedActor->GetActorLabel());

			// 컴포넌트 찾기
			UClickedComponent* ClickedComponent = ClickedActor->FindComponentByClass<UClickedComponent>();
			if (ClickedComponent)
			{
				ClickedComponent->Clicked();
			}
		}
	}
}