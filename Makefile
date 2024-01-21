NAMESPACE ?= default
IMG_NAME ?= ${DOCKER_IMAGE_NAME}

PRD_TAG ?= ${BITBUCKET_BUILD_NUMBER}
DEV_TAG ?= ${BITBUCKET_BUILD_NUMBER} 

# images
DEV_IMG_NAME ?= ${IMG_NAME}-dev:${DEV_TAG}
PRD_IMG_NAME ?= ${IMG_NAME}-prd:${PRD_TAG}


# image paths
#AWS_REPOSITORY_PATH ?= 034108791398.dkr.ecr.us-west-2.amazonaws.com
DEV_IMG ?= ${DOCKER_ECR_REPO_URL}/${DEV_IMG_NAME}
PRD_IMG ?= ${DOCKER_ECR_REPO_URL_PRD}/${PRD_IMG_NAME}

##################### Staging #############################
# docker image build tasks
.PHONY: build_image
build_image:
	@ echo "Building dev docker image for version ${DEV_TAG}"
	@ echo ${DEV_IMG}
	@ docker build -t ${DEV_IMG} .

# docker publish image tasks
.PHONY: publish_dev
publish_dev: build_image
	@ echo "Publishing image to dev registry"
	@ $$(aws ecr get-login --no-include-email --region us-west-2)
	@ docker push ${DEV_IMG}
	@ echo "Done publishing: ${DEV_IMG}"

##################### Prd #############################
# .PHONY: build_prd_image
# build_prd_image:
# 	@ echo "Building prd docker image for version ${PRD_TAG}"
# 	@ echo ${PRD_IMG}
# 	@ docker build -t ${PRD_IMG} .

# # docker publish image tasks
# .PHONY: publish_prd
# publish_prd: build_prd_image
# 	@ echo "Publishing image to prd registry"
# 	@ $$(aws ecr get-login --no-include-email --region ap-southeast-1)
# 	@ docker push ${PRD_IMG}
# 	@ echo "Done publishing: ${PRD_IMG}"
